using Business.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserToRegisterDto userToRegisterDto)
        {
            var registerResult = _authService.Register(userToRegisterDto);

            if (!registerResult.IsSuccess)
            {
                return BadRequest(registerResult.Message);
            }

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(UserToLoginDto userToLoginDto)
        {
            var loginResult = _authService.Login(userToLoginDto);

            if (!loginResult.IsSuccess)
            {
                return BadRequest(loginResult.Message);
            }

            AccessToken token = _authService.CreateAccessToken(loginResult.Data).Data;

            return Ok(token);
        }
    }
}
