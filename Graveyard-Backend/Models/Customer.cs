using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Graveyard.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Date_of_creation { get; set; }
        public string Password { get; set; }
        public string Owned_role { get; set; }
        public Customer(string name, string lastname, string email, string password)
        {
            Name = name; LastName = lastname; Email = email; Password = password;
            hashPassword();
            Date_of_creation = DateTime.Now;
            Owned_role = "User";
        }
        private void hashPassword()
        {
            var inputBytes = Encoding.UTF8.GetBytes(Password);
            var inputHash = SHA256.HashData(inputBytes);
            Password = Convert.ToHexString(inputHash);
        }
        public Customer() { }
    }
    [Keyless]
    public class OwnedGrave
    {
        public Customer customer { get; set; }
        public Grave grave { get; set; }
    }
}
