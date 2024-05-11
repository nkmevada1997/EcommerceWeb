using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Entity.Models
{
    public class AddStateRequest
    {
        [Required(ErrorMessage = "State is Required")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please Enter Only Letters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country Is Required")]
        [Display(Name = "Country")]
        public Guid CountryId { get; set; }
    }

    public class AddStateResponse : Wrapper
    {
        public bool Success { get; set; }
    }


    public class GetStatesResponse : Wrapper
    {
        public List<StateDTO> Result { get; set; } = [];
    }

    public class GetStateDetailResponse : Wrapper
    {
        public StateDTO? Result { get; set; }
    }

    public class EditStateRequest
    {
        public Guid StateId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please Enter Only Letters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Country")]
        public Guid CountryId { get; set; }
    }

    public class EditStateResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class DeleteStateResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class StateDTO : ModelBase
    {
        public required string Name { get; set; }

        public Guid CountryId { get; set; }

        public required CountryDTO Country { get; set; }
    }
}
