using Microsoft.AspNetCore.Mvc;
using Users.Core.DTOs;
using Users.Core.ServiceContracts;

namespace Users.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    // POST: api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("Invalid Credentials");
        }

        AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);

        if (authenticationResponse == null || authenticationResponse.Success is false)
        {
            return BadRequest(new { message = "Registration failed" });
        }

        return Ok(authenticationResponse);
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest == null)
        {
            return BadRequest("Invalid login request");
        }

        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

        if (authenticationResponse == null || authenticationResponse.Success is false)
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

        return Ok(authenticationResponse);
    }

    //POST: api/auth/Delete
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid guid)
    {
        if(guid == Guid.Empty)
        {
            return BadRequest("Invalid user ID");
        }

        bool isDeleted = await _usersService.Delete(guid);

        if (!isDeleted)
        {
            return NotFound("User not found or already deleted!");
        }

        return Ok("User Deleted Successfully!");
    }
}
