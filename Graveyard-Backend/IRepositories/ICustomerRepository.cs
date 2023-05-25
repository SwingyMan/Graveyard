using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface ICustomerRepository : ICRUDRepository<Customer>
{
	Task<Customer> getByEmail(string email);
	Task<Customer> getByEmailAndPassword(string email, string password);
	Task<Customer> updateByID(int id, Edit customer);
}