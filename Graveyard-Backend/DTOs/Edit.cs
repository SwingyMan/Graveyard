using System.Security.Cryptography;
using System.Text;

namespace Graveyard_Backend.DTOs;

public class Edit
{
    public string email { get; set; }
    public string password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Owned_role { get; set; }

    public void hashPassword()
    {
        var inputBytes = Encoding.UTF8.GetBytes(password);
        var inputHash = SHA256.HashData(inputBytes);
        password = Convert.ToHexString(inputHash);
    }
}