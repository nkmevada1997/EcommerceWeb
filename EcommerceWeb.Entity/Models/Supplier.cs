using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Entity.Models
{
    public class AddSupplierRequest
    {
        [Required(ErrorMessage = "Supplier Name Is Required.")]
        [Display(Name = "Supplier Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please Enter Only Letters")]
        [DataType(DataType.Text)]
        [MaxLength((20))]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address Is Required.")]
        [RegularExpression(@"^([a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4})+$", ErrorMessage = "Please enter correct email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength((50))]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password Is Required.")]
        [MinLength(8, ErrorMessage = "Password Length Must Be 8 to 15 Characters.")]
        [MaxLength(15, ErrorMessage = "Password Length Must Be 8 to 15 Characters.")]
        [RegularExpression(@"(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*#?&^_-]{8,15}$", ErrorMessage = "Invalid Password Pattern")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm Password Is Required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password Must Be Same.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Is Required.")]
        public Guid CountryId { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State Is Required.")]
        public Guid StateId { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City Is Required.")]
        public Guid CityId { get; set; }
    }

    public class AddSupplierResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class GetSuppliersResponse : Wrapper
    {
        public List<SupplierDTO> Result { get; set; } = [];
    }

    public class GetSupplierDetailResponse : Wrapper
    {
        public SupplierDTO? Result { get; set; }
    }

    public class EditSupplierRequest
    {
        public Guid SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier Name Is Required.")]
        [Display(Name = "Supplier Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please Enter Only Letters")]
        [DataType(DataType.Text)]
        [MaxLength((20))]
        public string SupplierName { get; set; } = string.Empty;

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country Is Required.")]
        public Guid CountryId { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State Is Required.")]
        public Guid StateId { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City Is Required.")]
        public Guid CityId { get; set; }
    }

    public class EditSupplierResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class DeleteSupplierResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class SupplierDTO : ModelBase
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public Guid CountryId { get; set; }

        public Guid StateId { get; set; }

        public Guid CityId { get; set; }
    }
}
