using AutoMapper;
using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using EcommerceWeb.Repository.Context;
using EcommerceWeb.Repository.Models;
using EcommerceWeb.Utility.Enum;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWeb.Repository.Repositories
{
    public class UserRepository(ApplicationDbContext context, IMapper mapper) : IUserRepository
    {
        readonly ApplicationDbContext _context = context;
        readonly IMapper _mapper = mapper;

        public async Task<AddUserResponse> AddUserAsync(AddUserRequest request)
        {
            try
            {
                var model = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    CreatedBy = Guid.Empty,
                    CreatedDate = DateTime.UtcNow,
                    CanLogin = true,
                    CustomerId = request.CustomerId,
                    SupplierId = request.SupplierId,
                    IsActive = true,
                    UserType = request.CustomerId.HasValue ? UserType.Customer : request.SupplierId.HasValue ? UserType.Supplier : UserType.Admin
                };

                await _context.Users.AddAsync(model);
                await _context.SaveChangesAsync();

                return new AddUserResponse
                {
                    IsError = false,
                    Success = true,
                    Message = "User Added Successfully"
                };
            }
            catch (Exception ex)
            {
                return new AddUserResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Add User",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<GetUsersResponse> GetUsersAsync()
        {
            try
            {
                var users = await _context.Users.AsQueryable().Where(x => x.IsActive && !x.IsBlocked).Include(customer => customer.Customer).Include(supplier => supplier.Supplier).ToListAsync();

                if (users != null && users.Count != 0)
                {
                    return new GetUsersResponse
                    {
                        IsError = false,
                        Message = "Records Retrieve",
                        Result = users.Select(user => _mapper.Map<UserDTO>(user)).ToList()
                    };
                }
                return new GetUsersResponse
                {
                    IsError = false,
                    Message = "Records Not Found",
                    Result = []
                };
            }
            catch (Exception ex)
            {
                return new GetUsersResponse
                {
                    IsError = true,
                    Message = "Something Went Wrong",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<GetUserDetailResponse> GetUserDetailAsync(Guid id)
        {
            try
            {
                var user = await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id && x.IsActive && !x.IsBlocked);

                if (user != null)
                {
                    return new GetUserDetailResponse
                    {
                        IsError = false,
                        Message = "User Retrieved",
                        Result = _mapper.Map<UserDTO>(user)
                    };
                }

                return new GetUserDetailResponse
                {
                    IsError = false,
                    Message = "User Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetUserDetailResponse
                {
                    IsError = true,
                    Message = "Something Went Wrong",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<GetUserDetailResponse> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var user = await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email && x.Password == password && x.IsActive && !x.IsBlocked);

                if (user != null)
                {
                    return new GetUserDetailResponse
                    {
                        IsError = false,
                        Message = "User Retrieved",
                        Result = _mapper.Map<UserDTO>(user)
                    };
                }

                return new GetUserDetailResponse
                {
                    IsError = false,
                    Message = "User Not Found",
                };
            }
            catch (Exception ex)
            {
                return new GetUserDetailResponse
                {
                    IsError = true,
                    Message = "Something Went Wrong",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<BlockUserResponse> BlockUserAsync(Guid id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsActive && !x.IsBlocked);

                if (user != null)
                {
                    user.IsBlocked = true;
                    user.UpdatedDate = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    return new BlockUserResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "User Blocked",
                        ErrorMessage = string.Empty
                    };
                }

                return new BlockUserResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "User Not Found",
                    ErrorMessage = string.Empty
                };

            }
            catch (Exception ex)
            {
                return new BlockUserResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Block the User",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<UnblockUserResponse> UnblockUserAsync(Guid id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsActive && x.IsBlocked);

                if (user != null)
                {
                    user.IsBlocked = false;
                    user.UpdatedDate = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    return new UnblockUserResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "User Unblocked",
                        ErrorMessage = string.Empty
                    };
                }

                return new UnblockUserResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "User Not Found",
                    ErrorMessage = string.Empty
                };

            }
            catch (Exception ex)
            {
                return new UnblockUserResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Unblock the User",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<DeleteUserResponse> DeleteUserAsync(Guid id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

                if (user != null)
                {
                    user.IsActive = false;
                    user.UpdatedDate = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    return new DeleteUserResponse
                    {
                        IsError = false,
                        Success = true,
                        Message = "User Deleted",
                        ErrorMessage = string.Empty
                    };
                }

                return new DeleteUserResponse
                {
                    IsError = false,
                    Success = false,
                    Message = "User Not Found",
                    ErrorMessage = string.Empty
                };

            }
            catch (Exception ex)
            {
                return new DeleteUserResponse
                {
                    IsError = true,
                    Success = false,
                    Message = "Unable to Delete the User",
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
