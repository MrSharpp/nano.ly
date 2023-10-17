using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
            new(JwtRegisteredClaimNames.Email, user.email.ToString())
            };

        var signinCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!)), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_config["JwtSettings:Issuer"], _config["JwtSettings:Audience"], claims, null, DateTime.UtcNow.AddHours(1), signinCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string RefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }

    public int? ValidateAccessToken(string token)
    {
        if (token == null) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config["JwtSettings:Key"]);
        try
        {
            var principles = tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = _config["JwtSettings:Issuer"],
                ValidAudience = _config["JwtSettings:Audience"],
                ValidateLifetime = false,
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            if (jwtToken == null) return null;

            return int.Parse(principles.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        catch (Exception _)
        {
            Console.WriteLine(_);
            return null;
        }
    }
}