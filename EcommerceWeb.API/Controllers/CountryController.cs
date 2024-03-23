using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(ICountryService service) : ControllerBase
    {
        private readonly ICountryService _service = service;

        [HttpPost("add-country")]
        public async Task<IActionResult> AddCountry([FromBody] AddCountryRequest request)
        {
            var result = await _service.AddCountry(request);
            return Ok(result);
        }

        [HttpGet("get-countries")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _service.GetCountries();
            return Ok(result);
        }

        [HttpGet("get-country-detail/{Id}")]
        public async Task<IActionResult> GetCountryDetail(Guid Id)
        {
            var result = await _service.GetCountryDetail(Id);
            return Ok(result);
        }

        [HttpPut("edit-country/{Id}")]
        public async Task<IActionResult> EditCountry(Guid Id, [FromBody] EditCountryRequest request)
        {
            var result = await _service.GetCountryDetail(Id);
            return Ok(result);
        }

        [HttpDelete("delete-country/{Id}")]
        public async Task<IActionResult> DeleteCountry(Guid Id)
        {
            var result = await _service.DeleteCountry(Id);
            return Ok(result);
        }
    }
}
