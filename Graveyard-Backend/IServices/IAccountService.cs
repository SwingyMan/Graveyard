using Graveyard.Models;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices
{
    public interface IAccountService
    {
        public Task<Customer> CreateUser(RegisterDTO registerDTO);
        public Task LoginUser(LoginDTO loginDTO);
        public Task<Customer> UpdateUser(int id, EditDTO editDTO);
        public Task DeleteUser(int id);
        public Task<Customer> GetUser(int id);
        public Task DeleteSelf();
        public Task<List<Customer>> GetAll();
    }
}
