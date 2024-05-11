using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Entity.Models
{
    public class AddCountryRequest
    {
        public string Name { get; set; } = string.Empty;
    }

    public class AddCountryResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class GetCountryDetailResponse : Wrapper
    {
        public CountryDTO? Result { get; set; }
    }

    public class GetCountriesResponse : Wrapper
    {
        public List<CountryDTO> Result { get; set; } = [];
    }

    public class EditCountryRequest
    {
        public string Name { get; set; } = string.Empty;
    }

    public class EditCountryResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class DeleteCountryResponse : Wrapper
    {
        public bool Success { get; set; }
    }

    public class CountryDTO : ModelBase
    {
        public required string Name { get; set; }
    }
}
