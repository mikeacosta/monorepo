using CodePulse.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    // POST: /api/auth/login
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var identityUser = await _userManager.FindByEmailAsync(request.Email);
        if (identityUser is not null)
        {
            var passwordResult = await _userManager.CheckPasswordAsync(identityUser, request.Password);
            if (passwordResult)
            {
                var roles = await _userManager.GetRolesAsync(identityUser);
                var response = new LoginResponseDto()
                {
                    Email = request.Email,
                    Roles = roles.ToList(),
                    Token = "TOKEN"
                };
                return Ok();
            }
        }
        
        ModelState.AddModelError("", "Email or Password is incorrect");
        return ValidationProblem(ModelState);
    }    

    // POST: /api/auth/register
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        var user = new IdentityUser
        {
            UserName = request.Email?.Trim(),
            Email = request.Email?.Trim()
        };

        var identityResult = await _userManager.CreateAsync(user, request.Password);
        if (identityResult.Succeeded)
        {
            identityResult = await _userManager.AddToRoleAsync(user, "Reader");
            if (identityResult.Succeeded)
                return Ok();
        }

        foreach (var error in identityResult.Errors)
            ModelState.AddModelError("", error.Description);

        return ValidationProblem();
    }
}