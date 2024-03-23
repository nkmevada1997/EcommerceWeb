using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;

namespace EcommerceWeb.Service
{
    public class StateService(IStateRepository repository) : IStateService
    {
        private readonly IStateRepository _repository = repository;

        public async Task<AddStateResponse> AddState(AddStateRequest request)
        {
            return await _repository.AddStateAsync(request);
        }

        public async Task<GetStatesResponse> GetStates()
        {
            return await _repository.GetStatesAsync();
        }

        public async Task<GetStateDetailResponse> GetStateDetail(Guid Id)
        {
            return await _repository.GetStateDetailAsync(Id);
        }

        public async Task<EditStateResponse> EditState(Guid Id, EditStateRequest request)
        {
            return await _repository.EditStateAsync(Id, request);
        }

        public async Task<DeleteStateResponse> DeleteState(Guid Id)
        {
            return await _repository.DeleteStateAsync(Id);
        }
    }
}
