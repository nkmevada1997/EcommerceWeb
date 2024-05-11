using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Entity.Models
{
    public class AddCityRequest
    {
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please Enter Only Letters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "State")]
        public Guid StateId { get; set; }

        public Guid CreatedBy { get; set; }
    }

    public class AddCityResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class GetCityDetailResponse : Wrapper
    {
        public CityDTO? Result { get; set; }
    }

    public class GetCitiesResponse : Wrapper
    {
        public List<CityDTO> Result { get; set; } = [];
    }

    public class EditCityRequest
    {
        public Guid CityId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Please Enter Only Letters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "State")]
        public Guid StateId { get; set; }
    }

    public class EditCityResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class DeleteCityResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class CityDTO : ModelBase
    {
        public required string Name { get; set; }

        public Guid StateId { get; set; }
    }
}
