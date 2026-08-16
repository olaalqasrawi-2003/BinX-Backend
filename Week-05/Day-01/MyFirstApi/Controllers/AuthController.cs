using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.RateLimiting;

namespace Microsoft.MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string email, string password)
    {
        var user = new IdentityUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok("User registered successfuly");
    }

    [HttpPost("Login")]
    [EnableRateLimiting("LoginPolicy")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if(user == null)
        {
            return Unauthorized("Invalid email or password");
        }
        var result = await _signInManager.CheckPasswordSignInAsync(
            user,
            password,
            false);
        if (!result.Succeeded)
        {
            return Unauthorized("Invalid email or password");
        }
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
          new Claim(JwtRegisteredClaimNames.Sub, user.Id),
          new Claim(ClaimTypes.Email, user.Email!)
        };
        foreach(var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
       var Key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(
               HttpContext.RequestServices.GetRequiredService<IConfiguration>()["Jwt:Key"]!
               ));

        var credentials = new SigningCredentials(
            Key,
            SecurityAlgorithms.HmacSha256
            );

       var token = new JwtSecurityToken(
        issuer: 
        HttpContext.RequestServices.GetRequiredService<IConfiguration>()["Jwt:Issuer"],
        audience: 
        HttpContext.RequestServices.GetRequiredService<IConfiguration>()["Jwt:audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(15),
          signingCredentials: credentials
       );
    
      var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

      return Ok(new
      {
          token = tokenString
      });

    }
}