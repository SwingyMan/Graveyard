using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Graveyard_Backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Graveyard_Backend.Services;

public static class JwtAuth
{
    public static string GenerateToken(Customer customer)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
            new(ClaimTypes.Email, customer.Email),
            new(ClaimTypes.Role, customer.Owned_role.ToString())
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(
            "48E55B3CBC709E10CF33C343714AA2386D7FF9EB9A983E6FD14CADF6982A62EC85D801B1876EB4D93F02725131CD763C528E01E4F427316574AA9BA01E4BDBF8431172BE3C29E17156BF586584A56F105E64F2F62ADC480A");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = "localhost:7079",
            Issuer = "localhost:7079",
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}