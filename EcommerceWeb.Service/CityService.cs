using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;

namespace EcommerceWeb.Service
{
    public class CityService(ICityRepository repository) : ICityService
    {
        private readonly ICityRepository _repository = repository;

        public async Task<AddCityResponse> AddCity(AddCityRequest request)
        {
            return await _repository.AddCityAsync(request);
        }

        public async Task<GetCitiesResponse> GetCities()
        {
            return await _repository.GetCitiesAsync();
        }

        public async Task<GetCityDetailResponse> GetCityDetail(Guid Id)
        {
            return await _repository.GetCityDetailAsync(Id);
        }

        public async Task<EditCityResponse> EditCity(Guid Id, EditCityRequest request)
        {
            return await _repository.EditCityAsync(Id, request);
        }

        public async Task<DeleteCityResponse> DeleteCity(Guid Id)
        {
            return await _repository.DeleteCityAsync(Id);
        }
    }
}
