using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(ICityService service) : ControllerBase
    {
        private readonly ICityService _service = service;

        [HttpPost("add-city")]
        public async Task<IActionResult> AddCity([FromBody] AddCityRequest request)
        {
            var result = await _service.AddCity(request);
            return Ok(result);
        }

        [HttpGet("get-cities")]
        public async Task<IActionResult> GetCities()
        {
            var result = await _service.GetCities();
            return Ok(result);
        }

        [HttpGet("get-city-detail/{Id}")]
        public async Task<IActionResult> GetCityDetail(Guid Id)
        {
            var result = await _service.GetCityDetail(Id);
            return Ok(result);
        }

        [HttpPut("edit-city/{Id}")]
        public async Task<IActionResult> EditCity(Guid Id, [FromBody] EditCityRequest request)
        {
            var result = await _service.EditCity(Id, request);
            return Ok(result);
        }

        [HttpDelete("delete-city/{Id}")]
        public async Task<IActionResult> DeleteCity(Guid Id)
        {
            var result = await _service.DeleteCity(Id);
            return Ok(result);
        }
    }
}
