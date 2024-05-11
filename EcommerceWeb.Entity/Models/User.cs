using EcommerceWeb.Utility.Enum;

namespace EcommerceWeb.Entity.Models
{
    public class AddUserRequest
    {
        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public UserType UserType { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid? SupplierId { get; set; }
    }

    public class AddUserResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class BlockUserResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class UnblockUserResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class DeleteUserResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class GetUserDetailResponse : Wrapper
    {
        public UserDTO? Result { get; set; }
    }

    public class GetUsersResponse : Wrapper
    {
        public List<UserDTO> Result { get; set; } = [];
    }

    public class UserDTO : ModelBase
    {
        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public UserType UserType { get; set; }

        public bool CanLogin { get; set; } = true;

        public Guid? CustomerId { get; set; }

        public Guid? SupplierId { get; set; }
    }
}
