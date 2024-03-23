using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController(ISupplierService service) : ControllerBase
    {
        private readonly ISupplierService _service = service;

        [HttpPost("add-supplier")]
        public async Task<IActionResult> AddSupplier([FromBody] AddSupplierRequest request)
        {
            var result = await _service.AddSupplier(request);
            return Ok(result);
        }

        [HttpGet("get-suppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var result = await _service.GetSuppliers();
            return Ok(result);
        }

        [HttpGet("get-supplier-detail/{Id}")]
        public async Task<IActionResult> GetSupplierDetail(Guid Id)
        {
            var result = await _service.GetSupplierDetail(Id);
            return Ok(result);
        }

        [HttpPut("edit-supplier/{Id}")]
        public async Task<IActionResult> EditSupplier(Guid Id, [FromBody] EditSupplierRequest request)
        {
            var result = await _service.EditSupplier(Id, request);
            return Ok(result);
        }

        [HttpDelete("delete-supplier/{Id}")]
        public async Task<IActionResult> DeleteSupplier(Guid Id)
        {
            var result = await _service.DeleteSupplier(Id);
            return Ok(result);
        }
    }
}
