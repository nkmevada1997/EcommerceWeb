using EcommerceWeb.Entity.Models;

namespace EcommerceWeb.Interface
{
    public interface ICountryService
    {
        Task<AddCountryResponse> AddCountry(AddCountryRequest request);
        Task<GetCountriesResponse> GetCountries();
        Task<GetCountryDetailResponse> GetCountryDetail(Guid Id);
        Task<EditCountryResponse> EditCountry(Guid Id, EditCountryRequest request);
        Task<DeleteCountryResponse> DeleteCountry(Guid Id);
    }

    public interface ICountryRepository
    {
        Task<AddCountryResponse> AddCountryAsync(AddCountryRequest request);
        Task<GetCountriesResponse> GetCountriesAsync();
        Task<GetCountryDetailResponse> GetCountryDetailAsync(Guid Id);
        Task<EditCountryResponse> EditCountryAsync(Guid Id, EditCountryRequest request);
        Task<DeleteCountryResponse> DeleteCountryAsync(Guid Id);
    }
}
