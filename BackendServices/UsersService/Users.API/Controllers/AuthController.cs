using Microsoft.AspNetCore.Mvc;
using Users.Core.DTOs;
using Users.Core.ServiceContracts;

namespace Users.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Invalid Credintials");
            }

            AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);

            if (authenticationResponse == null || authenticationResponse.Success is false)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid login request");
            }

            AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);
            if(authenticationResponse == null || authenticationResponse.Success is false)
            {
                return NotFound("User not found");
            }

            return Ok(authenticationResponse);
        }
    }
}
