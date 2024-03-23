using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using EcommerceWeb.Utility.Encode;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService service) : ControllerBase
    {
        private readonly ICustomerService _service = service;

        [HttpPost("add-customer")]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {
            var result = await _service.AddCustomer(request);
            return Ok(result);
        }

        [HttpGet("get-customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _service.GetCustomers();
            return Ok(result);
        }

        [HttpGet("get-customer-detail/{Id}")]
        public async Task<IActionResult> GetCustomerDetail(Guid Id)
        {
            var result = await _service.GetCustomerDetail(Id);
            return Ok(result);
        }

        [HttpPut("edit-customer/{Id}")]
        public async Task<IActionResult> EditCustomer(Guid Id, [FromBody] EditCustomerRequest request)
        {
            var result = await _service.EditCustomer(Id, request);
            return Ok(result);
        }

        [HttpDelete("delete-customer/{Id}")]
        public async Task<IActionResult> DeleteCustomer(Guid Id)
        {
            var result = await _service.DeleteCustomer(Id);
            return Ok(result);
        }
    }
}
