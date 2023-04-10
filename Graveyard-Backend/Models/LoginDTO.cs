using System.Security.Cryptography;
using System.Text;

namespace Graveyard_Backend.Models
{
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
}
