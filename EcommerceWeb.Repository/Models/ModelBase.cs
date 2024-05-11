using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Repository.Models
{
    public class ModelBase
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; } = null;

        public Guid? UpdatedBy { get; set; } = null;

        public bool IsActive { get; set; } = true;

        public bool IsBlocked { get; set; } = false;
    }
}
