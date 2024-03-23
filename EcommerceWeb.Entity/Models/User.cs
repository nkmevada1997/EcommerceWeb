using EcommerceWeb.Utility.Enum;

namespace EcommerceWeb.Entity.Models
{
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
