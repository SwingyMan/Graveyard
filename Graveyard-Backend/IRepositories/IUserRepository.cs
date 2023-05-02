using Graveyard.Models;

namespace Graveyard_Backend.Interfaces
{
    public interface IUserRepository : ICRUDRepository<Customer>
    {
        Task<Customer> getByEmail(string email);
        Task<Customer> getByEmailAndPassword(string email, string password);
    }
}
