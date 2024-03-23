using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWeb.Repository.Models
{
    [Table("Customers", Schema = "dbo")]
    public class Customer : ModelBase
    {
        public required string FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DOB { get; set; }

        public required string Gender { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Password { get; set; }

        public Guid CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }

        public Guid StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual  State? State { get; set; }

        public Guid CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual  City? City { get; set; }

    }
}
