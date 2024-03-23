using EcommerceWeb.Entity.Models;
using EcommerceWeb.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController(IStateService service) : Controller
    {
        private readonly IStateService _service = service;

        [HttpPost("add-state")]
        public async Task<IActionResult> AddState([FromBody] AddStateRequest request)
        {
            var result = await _service.AddState(request);
            return Ok(result);
        }

        [HttpGet("get-states")]
        public async Task<IActionResult> GetStates()
        {
            var result = await _service.GetStates();
            return Ok(result);
        }

        [HttpGet("get-state-detail/{Id}")]
        public async Task<IActionResult> GetStateDetail(Guid Id)
        {
            var result = await _service.GetStateDetail(Id);
            return Ok(result);
        }

        [HttpPut("edit-state/{Id}")]
        public async Task<IActionResult> EditState(Guid Id, [FromBody] EditStateRequest request)
        {
            var result = await _service.EditState(Id, request);
            return Ok(result);
        }

        [HttpDelete("delete-state/{Id}")]
        public async Task<IActionResult> DeleteState(Guid Id)
        {
            var result = await _service.DeleteState(Id);
            return Ok(result);
        }
    }
}
