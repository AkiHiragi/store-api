using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using store_api.Models;

namespace store_api.Service;

public class JwtTokenGenerator(IConfiguration configuration)
{
    private readonly string _secretKey =
        configuration["AuthSettings:SecretKey"] ?? throw new InvalidOperationException();

    public string GenerateJwtToken(AppUser appUser, List<string> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim("FirstName", appUser.FirstName),
                new Claim("id", appUser.Id),
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim(ClaimTypes.Role, string.Join(",", roles))
            ]),

            Expires = DateTime.UtcNow.AddDays(1),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}