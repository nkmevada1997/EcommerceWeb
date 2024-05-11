using EcommerceWeb.Entity.Models;

namespace EcommerceWeb.Interface
{
    public interface IUserService
    {
        Task<AddUserResponse> AddUser(AddUserRequest request);
        Task<GetUsersResponse> GetUsers();
        Task<GetUserDetailResponse> GetUserDetail(Guid id);
        Task<GetUserDetailResponse> GetUserByEmailAndPassword(string email, string password);
        Task<BlockUserResponse> BlockUser(Guid id);
        Task<UnblockUserResponse> UnblockUser(Guid id);
        Task<DeleteUserResponse> DeleteUser(Guid id);

    }

    public interface IUserRepository
    {
        Task<AddUserResponse> AddUserAsync(AddUserRequest request);
        Task<GetUsersResponse> GetUsersAsync();
        Task<GetUserDetailResponse> GetUserDetailAsync(Guid id);
        Task<GetUserDetailResponse> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<BlockUserResponse> BlockUserAsync(Guid id);
        Task<UnblockUserResponse> UnblockUserAsync(Guid id);
        Task<DeleteUserResponse> DeleteUserAsync(Guid id);
    }
}
