using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;

namespace EcommerceWeb.Service
{
    public class UserService(IUserRepository repository) : IUserService
    {
        readonly IUserRepository _repository = repository;

        public async Task<AddUserResponse> AddUser(AddUserRequest request)
        {
            return await _repository.AddUserAsync(request);
        }

        public async Task<GetUsersResponse> GetUsers()
        {
            return await _repository.GetUsersAsync();
        }

        public async Task<GetUserDetailResponse> GetUserDetail(Guid id)
        {
            return await _repository.GetUserDetailAsync(id);
        }

        public async Task<GetUserDetailResponse> GetUserByEmailAndPassword(string email, string password)
        {
            return await _repository.GetUserByEmailAndPasswordAsync(email, password);
        }

        public async Task<BlockUserResponse> BlockUser(Guid id)
        {
            return await _repository.BlockUserAsync(id);
        }

        public async Task<UnblockUserResponse> UnblockUser(Guid id)
        {
            return await _repository.UnblockUserAsync(id);
        }

        public async Task<DeleteUserResponse> DeleteUser(Guid id)
        {
            return await _repository.DeleteUserAsync(id);
        }
    }
}
