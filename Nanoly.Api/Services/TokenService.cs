using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Nanoly.Entities;

namespace Nanoly.Services;

public class TokenService
{
    private readonly IConfigurationRoot _config;
    public TokenService(IConfiguration configuration)
    {
        _config = (IConfigurationRoot)configuration;
    }

    public string GenerateToken(User user)
    {
        var claims = new Claim[] {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email.ToString())
            };

        var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!)), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_config["JwtSettings:Issuer"], _config["JwtSettings:Audience"], claims, null, DateTime.UtcNow.AddHours(1), signinCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}