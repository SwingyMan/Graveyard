using Graveyard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Graveyard_Backend.Models
{
    public class JwtAuth
    {
        public string GenerateToken(Customer customer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("48E55B3CBC709E10CF33C343714AA2386D7FF9EB9A983E6FD14CADF6982A62EC85D801B1876EB4D93F02725131CD763C528E01E4F427316574AA9BA01E4BDBF8431172BE3C29E17156BF586584A56F105E64F2F62ADC480A"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,customer.Name),
                new Claim(ClaimTypes.Role,customer.Owned_role)
            };
            var token = new JwtSecurityToken(
                issuer: "localhost:7079",
                audience: "localhost:7079",
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
