using AutoMapper;
using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using EcommerceWeb.Repository.Context;
using EcommerceWeb.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Repository.Repositories
{
    public class CountryRepository(IMapper mapper, ApplicationDbContext context) : ICountryRepository
    {
        readonly IMapper _mapper = mapper;
        readonly ApplicationDbContext _context = context;

        public async Task<AddCountryResponse> AddCountryAsync(AddCountryRequest request)
        {
            try
            {
                await _context.Countries.AddAsync(new Country
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    CreatedDate = DateTime.UtcNow
                });

                await _context.SaveChangesAsync();

                return new AddCountryResponse
                {
                    IsError = false,
                    Success = true,
                    Message = "Country Added",
                    ErrorMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new AddCountryResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Add Country",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<GetCountriesResponse> GetCountriesAsync()
        {
            try
            {
                var countries = await _context.Countries.Where(x => x.IsActive).ToListAsync();

                if (countries != null && countries.Count != 0)
                {
                    var result = new List<CountryDTO>();

                    foreach (var country in countries)
                    {
                        result.Add(_mapper.Map<CountryDTO>(country));
                    }

                    return new GetCountriesResponse
                    {
                        IsError = false,
                        Result = result,
                        Message = "Record Retrieve",
                    };
                }

                return new GetCountriesResponse
                {
                    IsError = false,
                    Result = [],
                    Message = "Record Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetCountriesResponse
                {
                    IsError = true,
                    Message = "Unable to Get Data",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<GetCountryDetailResponse> GetCountryDetailAsync(Guid Id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (country != null)
                {
                    return new GetCountryDetailResponse
                    {
                        IsError = false,
                        Result = _mapper.Map<CountryDTO>(country),
                        Message = "Record Retrieve",
                    };
                }

                return new GetCountryDetailResponse
                {
                    IsError = false,
                    Result = null,
                    Message = "Record Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetCountryDetailResponse
                {
                    IsError = true,
                    Result = null,
                    Message = "Unable to Fetch Data",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<EditCountryResponse> EditCountryAsync(Guid Id, EditCountryRequest request)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (country != null)
                {
                    country.Name = request.Name;
                    country.UpdatedBy = Guid.Empty;
                    country.UpdatedDate = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    return new EditCountryResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "Country Updated",
                        ErrorMessage = string.Empty
                    };
                }

                return new EditCountryResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Record Not Found",
                    ErrorMessage = string.Empty
                };

            }
            catch (Exception ex)
            {
                return new EditCountryResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Update the Record",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<DeleteCountryResponse> DeleteCountryAsync(Guid Id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == Id && x.IsActive);

                if (country != null)
                {
                    country.IsActive = false;
                    await _context.SaveChangesAsync();

                    return new DeleteCountryResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "Country Deleted",
                        ErrorMessage = string.Empty
                    };
                }

                return new DeleteCountryResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "Record Not Found",
                    ErrorMessage = string.Empty
                };
            }
            catch (Exception ex)
            {
                return new DeleteCountryResponse
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
