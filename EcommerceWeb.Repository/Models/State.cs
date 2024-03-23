using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWeb.Repository.Models
{
    [Table("States", Schema = "dbo")]
    public class State : ModelBase
    {
        public required string Name { get; set; } 

        public virtual Guid CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual required Country Country { get; set; }
    }
}
