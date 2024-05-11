namespace EcommerceWeb.Entity.Models
{
    public class Wrapper
    {
        public bool IsError { get; set; }

        public required string Message { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
