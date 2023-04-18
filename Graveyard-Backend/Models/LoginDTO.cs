using System.Security.Cryptography;
using System.Text;

namespace Graveyard_Backend.Models;

public class LoginDTO
{
    public string email { get; set; }
    public string password { get; set; }

    public void hashPassword()
    {
        var inputBytes = Encoding.UTF8.GetBytes(password);
        var inputHash = SHA256.HashData(inputBytes);
        password = Convert.ToHexString(inputHash);
    }
}

public class RegisterDTO
{
    public string email { get; set; }
    public string password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class EditDTO
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

public class ItemDTO
{
    public decimal price { get; set; }
    public int quantity { get; set; }
    public string kind { get; set; }
}

public class GraveDTO
{
    public int x { get; set; }
    public int y { get; set; }
    public string status { get; set; }
    public string name { get; set; }
    public string lastname { get; set; }
    public DateOnly date_of_birth { get; set; }
    public DateOnly date_of_death { get; set; }
}

public class BurialDTO
{
    public string name { get; set; }
    public string lastname { get; set; }
    public DateOnly date_of_birth { get; set; }
    public DateOnly date_of_death { get; set; }
    public DateTime burial_date { get; set; }
}