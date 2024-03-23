using AutoMapper;
using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using EcommerceWeb.Repository.Context;
using EcommerceWeb.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Repository.Repositories
{
    public class CityRepository(IMapper mapper, ApplicationDbContext context) : ICityRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly ApplicationDbContext _context = context;

        public async Task<AddCityResponse> AddCityAsync(AddCityRequest request)
        {
            try
            {
                var city = _mapper.Map<City>(request);
                city.Id = Guid.NewGuid();
                city.CreatedDate = DateTime.UtcNow;

                await _context.Cities.AddAsync(city);
                await _context.SaveChangesAsync();

                return new AddCityResponse
                {
                    IsError = false,
                    Success = true,
                    Message = "City Added",
                    ExceptionMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new AddCityResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Add City",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<GetCitiesResponse> GetCitiesAsync()
        {
            try
            {
                var cities = await _context.Cities.Where(x => x.IsActive).ToListAsync();

                if (cities != null && cities.Count != 0)
                {

                    var result = new List<CityDTO>();

                    foreach (var city in cities)
                    {
                        result.Add(_mapper.Map<CityDTO>(city));
                    }
                    return new GetCitiesResponse
                    {
                        IsError = false,
                        Result = result,
                        Message = "Record Retrieve",
                    };
                }

                return new GetCitiesResponse
                {
                    IsError = false,
                    Result = [],
                    Message = "Record Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetCitiesResponse
                {
                    IsError = true,
                    Message = "Unable to Get Data",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<GetCityDetailResponse> GetCityDetailAsync(Guid Id)
        {
            try
            {
                var city = await _context.Countries.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (city != null)
                {
                    return new GetCityDetailResponse
                    {
                        IsError = false,
                        Result = _mapper.Map<CityDTO>(city),
                        Message = "Record Retrieve",
                    };
                }

                return new GetCityDetailResponse
                {
                    IsError = false,
                    Result = null,
                    Message = "Record Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetCityDetailResponse
                {
                    IsError = true,
                    Result = null,
                    Message = "Unable to Fetch Data",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<EditCityResponse> EditCityAsync(Guid Id, EditCityRequest request)
        {
            try
            {
                var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (city != null)
                {
                    city = _mapper.Map<City>(request);
                    city.UpdatedBy = Guid.Empty;
                    city.UpdatedDate = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    return new EditCityResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "City Updated",
                        ExceptionMessage = string.Empty
                    };
                }

                return new EditCityResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Record Not Found",
                    ExceptionMessage = string.Empty
                };

            }
            catch (Exception ex)
            {
                return new EditCityResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Update the Record",
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<DeleteCityResponse> DeleteCityAsync(Guid Id)
        {
            try
            {
                var city = await _context.Countries.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (city != null)
                {
                    city.IsActive = false;
                    await _context.SaveChangesAsync();

                    return new DeleteCityResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "City Deleted",
                        ExceptionMessage = string.Empty
                    };
                }

                return new DeleteCityResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Record Not Found",
                    ExceptionMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new DeleteCityResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Update the Record",
                    ExceptionMessage = ex.Message
                };
            }
        }
    }
}
