using CardiacPatientMonitoringSystem.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.RateLimiting;

namespace CardiacPatientMonitoringSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AuthController(
    UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration configuration)
{
    _userManager = userManager;
    _roleManager = roleManager;
    _configuration = configuration;
}

    [HttpPost("register")]
public async Task<IActionResult> Register(RegisterDto dto)
{
    var existingUser = await _userManager.FindByEmailAsync(dto.Email);

    if (existingUser != null)
    {
        return BadRequest("Email is already registered.");
    }

    var user = new IdentityUser
    {
        UserName = dto.Email,
        Email = dto.Email
    };

    var result = await _userManager.CreateAsync(user, dto.Password);

    if (!result.Succeeded)
    {
        return BadRequest(
            result.Errors.Select(error => error.Description)
        );
    }

    if (!await _roleManager.RoleExistsAsync("User"))
    {
        await _roleManager.CreateAsync(new IdentityRole("User"));
    }

    if (!await _roleManager.RoleExistsAsync("Admin"))
    {
        await _roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    await _userManager.AddToRoleAsync(user, "User");

    return Ok(new
    {
        Message = "User registered successfully.",
        Email = user.Email
    });
}
   

    [HttpPost("login")]
    [EnableRateLimiting("LoginPolicy")]
public async Task<IActionResult> Login(LoginDto dto)
{
     var user = await _userManager.FindByEmailAsync(dto.Email);

         if (user == null)
            {
                return Unauthorized("Invalid email or password.");
             }

    var passwordValid = await _userManager.CheckPasswordAsync(
        user,
        dto.Password
    );
    var roles = await _userManager.GetRolesAsync(user);
    if (!passwordValid)
    {
        return Unauthorized("Invalid email or password.");
    }

    var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
    };
    foreach(var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(
            _configuration["Jwt:Key"]!
        )
    );

    var credentials = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256
    );

    var expiryMinutes = int.Parse(
        _configuration["Jwt:ExpiryMinutes"]!
    );

    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
        signingCredentials: credentials
    );

    var tokenString = new JwtSecurityTokenHandler()
        .WriteToken(token);

    return Ok(new
    {
        Token = tokenString,
        ExpiresInMinutes = expiryMinutes
    });
}
}