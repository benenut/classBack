using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {

        public readonly AuthServices _authServices;

        public AuthController(AuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("signIn")]
        public async Task<ActionResult> SignInAsync(SignInDTO user)
        {
            await _authServices.SignInAsync(user);
            return Ok();
        }

        [HttpPost("role")]
        public async Task<ActionResult> RoleAsync(RoleDTO role)
        {
            await _authServices.RoleAsync(role);
            return Ok(); 
        }

    }
}
