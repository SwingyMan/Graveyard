using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Graveyard.Models
{
    public class Customer
    {
        [Key]
        public int Id_c { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Date_of_creation { get; set; }
        public byte[] Password { get; set; }
        public Customer(string name,string lastname,string email,string password) { 
            Name = name; LastName = lastname; Email = email; 
            Password = SHA256.HashData(Encoding.ASCII.GetBytes(password));
            Date_of_creation = DateTime.Now;
        }
        public Customer() { }
    }
    [Keyless]
    public class Owned_Role {
     public Customer Customer { get; set; }
     public string Role { get; set; }
    }
    [Keyless]
    public class OwnedGrave
    {
        public Customer customer { get; set; }
        public Grave grave { get; set; }
    }
}
