using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API_PRODUCT.Application.DTOs;
using API_PRODUCT.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace API_PRODUCT.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly AuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthController(AuthService authService, IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
        
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        _authService.Register(request);
        return Ok("Utilisateur créé");
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = _authService.Login(request);

        var tokenHandler = new JwtSecurityTokenHandler();
        var secretKey = _configuration["Jwt:Key"]
                        ?? throw new InvalidOperationException("JWT Key not configured");



        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Ok(new
        {
            Token = tokenHandler.WriteToken(token)
        });
    }
}