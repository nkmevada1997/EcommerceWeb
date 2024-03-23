using EcommerceWeb.Entity.Models;

namespace EcommerceWeb.Interface
{
    public interface IStateService
    {
        Task<AddStateResponse> AddState(AddStateRequest request);
        Task<GetStatesResponse> GetStates();
        Task<GetStateDetailResponse> GetStateDetail(Guid Id);
        Task<EditStateResponse> EditState(Guid Id, EditStateRequest request);
        Task<DeleteStateResponse> DeleteState(Guid Id);
    }

    public interface IStateRepository
    {
        Task<AddStateResponse> AddStateAsync(AddStateRequest request);
        Task<GetStatesResponse> GetStatesAsync();
        Task<GetStateDetailResponse> GetStateDetailAsync(Guid Id);
        Task<EditStateResponse> EditStateAsync(Guid Id, EditStateRequest request);
        Task<DeleteStateResponse> DeleteStateAsync(Guid Id);
    }
}
