using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;

namespace EcommerceWeb.Service
{
    public class CountryService(ICountryRepository repository) : ICountryService
    {
        readonly ICountryRepository _repository = repository;

        public async Task<AddCountryResponse> AddCountry(AddCountryRequest request)
        {
            return await _repository.AddCountryAsync(request);
        }

        public async Task<GetCountriesResponse> GetCountries()
        {
            return await _repository.GetCountriesAsync();
        }

        public async Task<GetCountryDetailResponse> GetCountryDetail(Guid Id)
        {
            return await _repository.GetCountryDetailAsync(Id);
        }

        public async Task<EditCountryResponse> EditCountry(Guid Id, EditCountryRequest request)
        {
            return await _repository.EditCountryAsync(Id, request);
        }

        public async Task<DeleteCountryResponse> DeleteCountry(Guid Id)
        {
            return await _repository.DeleteCountryAsync(Id);
        }
    }
}
