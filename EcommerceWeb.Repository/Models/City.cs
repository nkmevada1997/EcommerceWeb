using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceWeb.Repository.Models
{
    [Table("Cities", Schema = "dbo")]
    public class City : ModelBase
    {
        public required string Name { get; set; }

        public Guid StateId { get; set; }

        [ForeignKey("StateId")]
        [JsonIgnore]
        public virtual State State { get; set; }
    }
}
