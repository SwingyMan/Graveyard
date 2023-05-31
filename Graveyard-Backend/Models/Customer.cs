using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Models;

[Index(nameof(Email), nameof(Password))]
public class Customer
{
    public Customer(string name, string lastname, string email, string password)
    {
        Name = name;
        LastName = lastname;
        Email = email.ToLower();
        Password = password;
        hashPassword();
        Date_of_creation = DateTime.Now;
        Owned_role = Role.User;
    }

    public Customer()
    {
    }

    [Key] public int CustomerId { get; set; }

    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Date_of_creation { get; set; }
    public string Password { get; set; }
    public Role Owned_role { get; set; }
    public List<Cart> carts { get; set; } = null;

    private void hashPassword()
    {
        var inputBytes = Encoding.UTF8.GetBytes(Password);
        var inputHash = SHA256.HashData(inputBytes);
        Password = Convert.ToHexString(inputHash);
    }
}

public enum Role
{
    User,
    Administrator
}