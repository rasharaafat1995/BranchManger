using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            var token = GenerateJwtToken(user);
            return Ok(new { token, userName = model.Username });
        }
        return Unauthorized();
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

//[Route("api/[controller]")]
//[ApiController]
//public class AccountController : ControllerBase
//{
//    private readonly UserManager<IdentityUser> _userManager;
//    private readonly SignInManager<IdentityUser> _signInManager;
//    private readonly IConfiguration _configuration;

//    public AccountController(UserManager<IdentityUser> userManager,
//                             SignInManager<IdentityUser> signInManager,
//                             IConfiguration configuration)
//    {
//        _userManager = userManager;
//        _signInManager = signInManager;
//        _configuration = configuration;
//    }

//    [HttpPost("Login")]
//    public async Task<IActionResult> Login([FromBody] LoginModel model)
//    {
//        var user = await _userManager.FindByNameAsync(model.Username);
//        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
//        {
//            var authClaims = new[]
//            {
//                new Claim(ClaimTypes.Name, user.UserName),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//            };

//            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

//            var token = new JwtSecurityToken(
//                issuer: _configuration["Jwt:Issuer"],
//                audience: _configuration["Jwt:Audience"],
//                expires: DateTime.Now.AddHours(3),
//                claims: authClaims,
//                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
//            );

//            return Ok(new
//            {
//                token = new JwtSecurityTokenHandler().WriteToken(token),
//                expiration = token.ValidTo
//            });
//        }
//        return Unauthorized();
//    }
//}

//public class LoginModel
//{
//    public string Username { get; set; }
//    public string Password { get; set; }
//}
