using Graveyard.Models;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Interfaces
{
    public interface IUserRepository : ICRUDRepository<Customer>
    {
        Task<Customer> getByEmail(string email);
        Task<Customer> getByEmailAndPassword(string email, string password);
        Task<Customer> updateByID(int id, EditDTO customer);
    }
}
