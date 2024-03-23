using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Entity.Models
{
    public class AddCustomerRequest
    {
        [Required(ErrorMessage = "First Name Is Required.")]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter Only Letters")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter Only Letters")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address Is Required.")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile Number Is Required.")]
        [MaxLength(20)]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^([0-9]{10})+$", ErrorMessage = "Please Enter Only Numbers")]
        public string PhoneNumber { get; set; } = string.Empty;

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

        [Required(ErrorMessage = "DOB Is Required.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender Is Required.")]
        public required string Gender { get; set; }

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

    public class AddCustomerResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class GetCustomerDetailResponse : Wrapper
    {
        public CustomerDTO? Result { get; set; }
    }

    public class GetCustomersResponse : Wrapper
    {
        public List<CustomerDTO> Result { get; set; } = [];
    }

    public class EditCustomerRequest
    {
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "First Name Is Required.")]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter Only Letters")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter Only Letters")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender Is Required.")]
        public required string Gender { get; set; }

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

    public class EditCustomerResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class DeleteCustomerResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class CustomerDTO : ModelBase
    {
        public required string FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DOB { get; set; }

        public required string Gender { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Password { get; set; }

        public Guid CountryId { get; set; }

        public Guid StateId { get; set; }

        public Guid CityId { get; set; }
    }
}
