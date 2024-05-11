using EcommerceWeb.Entity.Models;
using EcommerceWeb.Service;
using EcommerceWeb.Utility.Encode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EcommerceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(UserService service, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : ControllerBase
    {
        readonly UserService _service = service;
        readonly IConfiguration _configuration = configuration;
        readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        [HttpGet]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _service.GetUserByEmailAndPassword(model.Email, EncodeBase.EncodeBase64(model.Password));

            if (!result.IsError)
            {
                _httpContextAccessor.HttpContext.Session.SetString("UserId", result.Result.Id.ToString());
            }

            return Ok("Login Successfully");
        }

        private void GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
