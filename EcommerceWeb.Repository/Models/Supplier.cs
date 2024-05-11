using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWeb.Repository.Models
{
    [Table("Suppliers", Schema = "dbo")]
    public class Supplier : ModelBase
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public Guid CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }

        public Guid StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual State? State { get; set; }

        public Guid CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City? City { get; set; }
    }
}
