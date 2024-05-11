using AutoMapper;
using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using EcommerceWeb.Repository.Context;
using EcommerceWeb.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Repository.Repositories
{
    public class StateRepository(IMapper mapper, ApplicationDbContext context) : IStateRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly ApplicationDbContext _context = context;

        public async Task<AddStateResponse> AddStateAsync(AddStateRequest request)
        {
            try
            {

                await _context.States.AddAsync(new State
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    CountryId = request.CountryId,
                    CreatedDate = DateTime.UtcNow,
                });
                await _context.SaveChangesAsync();

                return new AddStateResponse
                {
                    IsError = false,
                    Success = true,
                    Message = "State Added",
                    ErrorMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new AddStateResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Add State",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<GetStatesResponse> GetStatesAsync()
        {
            try
            {
                var states = await _context.States.Where(x => x.IsActive).Include(country => country.Country).ToListAsync();

                if (states != null && states.Count != 0)
                {
                    return new GetStatesResponse
                    {
                        IsError = false,
                        Result = states.Select(state => _mapper.Map<StateDTO>(state)).ToList(),
                        Message = "Record Retrieve",
                    };
                }

                return new GetStatesResponse
                {
                    IsError = false,
                    Result = [],
                    Message = "Record Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetStatesResponse
                {
                    IsError = true,
                    Message = "Unable to Get Data",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<GetStateDetailResponse> GetStateDetailAsync(Guid Id)
        {
            try
            {
                var state = await _context.States.Include(country => country.Country).FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (state != null)
                {
                    return new GetStateDetailResponse
                    {
                        IsError = false,
                        Result = _mapper.Map<StateDTO>(state),
                        Message = "Record Retrieve",
                    };
                }

                return new GetStateDetailResponse
                {
                    IsError = false,
                    Result = null,
                    Message = "Record Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetStateDetailResponse
                {
                    IsError = true,
                    Result = null,
                    Message = "Unable to Fetch Data",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<EditStateResponse> EditStateAsync(Guid Id, EditStateRequest request)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (state != null)
                {
                    state.Name = request.Name;
                    state.CountryId = request.CountryId;
                    state.UpdatedBy = Guid.Empty;
                    state.UpdatedDate = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    return new EditStateResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "State Updated",
                        ErrorMessage = string.Empty
                    };
                }

                return new EditStateResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Record Not Found",
                    ErrorMessage = string.Empty
                };

            }
            catch (Exception ex)
            {
                return new EditStateResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Update the Record",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<DeleteStateResponse> DeleteStateAsync(Guid Id)
        {
            try
            {
                var state = await _context.Countries.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (state != null)
                {
                    state.IsActive = false;
                    await _context.SaveChangesAsync();

                    return new DeleteStateResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "State Deleted",
                        ErrorMessage = string.Empty
                    };
                }

                return new DeleteStateResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Record Not Found",
                    ErrorMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new DeleteStateResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Update the Record",
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
