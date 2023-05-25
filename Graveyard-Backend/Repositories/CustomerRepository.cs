using Graveyard_Backend.DTOs;
using Microsoft.EntityFrameworkCore;
using Graveyard_Backend.Models;
using Graveyard_Backend.IRepositories;

namespace Graveyard_Backend.Repositories;

public class CustomerRepository : CRUDRepository<Customer>, ICustomerRepository
{
    private readonly contextModel _contextModel;

    public CustomerRepository(contextModel contextModel)
    {
        _contextModel = contextModel;
    }

    public async Task<Customer> getByEmail(string email)
    {
        var account = await _contextModel.customer.FirstOrDefaultAsync(x => x.Equals(email));
        if (account == null)
            return null;
        return account;
    }

    public async Task<Customer> getByEmailAndPassword(string email, string password)
    {
        var account = await _contextModel.customer.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        if (account == null)
            return null;
        return account;
    }

    public async Task<Customer> updateByID(int id, Edit customer)
    {
        var original = _contextModel.customer.FirstOrDefault(x => x.CustomerId == id);
        if (!string.IsNullOrEmpty(customer.FirstName))
            original.Name = customer.FirstName;
        if (!string.IsNullOrEmpty(customer.LastName))
            original.LastName = customer.LastName;
        if (!string.IsNullOrEmpty(customer.email))
            original.Email = customer.email;
        if (!string.IsNullOrEmpty(customer.password))
            original.Password = customer.password;
        await _contextModel.SaveChangesAsync();
        return original;
    }
}