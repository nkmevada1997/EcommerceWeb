using EcommerceWeb.Entity.Models;

namespace EcommerceWeb.Interface
{
    public interface ICityService
    {
        Task<AddCityResponse> AddCity(AddCityRequest request);
        Task<GetCitiesResponse> GetCities();
        Task<GetCityDetailResponse> GetCityDetail(Guid Id);
        Task<EditCityResponse> EditCity(Guid Id, EditCityRequest request);
        Task<DeleteCityResponse> DeleteCity(Guid Id);
    }

    public interface ICityRepository
    {
        Task<AddCityResponse> AddCityAsync(AddCityRequest request);
        Task<GetCitiesResponse> GetCitiesAsync();
        Task<GetCityDetailResponse> GetCityDetailAsync(Guid Id);
        Task<EditCityResponse> EditCityAsync(Guid Id, EditCityRequest request);
        Task<DeleteCityResponse> DeleteCityAsync(Guid Id);
    }
}
