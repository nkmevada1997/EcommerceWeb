namespace EcommerceWeb.Entity.Models
{
    public class ModelBase
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
