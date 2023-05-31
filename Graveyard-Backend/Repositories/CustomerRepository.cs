using Graveyard_Backend.DTOs;
using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories;

public class CustomerRepository : CRUDRepository<Customer>, ICustomerRepository
{
    private readonly ContextModel _contextModel;

    public CustomerRepository(ContextModel contextModel)
    {
        _contextModel = contextModel;
    }

    public async Task<Customer> getByEmail(string email)
    {
        var account = await _contextModel.customer.FirstOrDefaultAsync(x => x.Email.Equals(email));
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

    public async Task<Customer> setAdminRole(int CustomerId)
    {
        var customer = await _contextModel.customer.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
        customer.Owned_role = Role.Administrator;
        await _contextModel.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> removeAdminRole(int CustomerId)
    {
        var customer = await _contextModel.customer.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
        customer.Owned_role = Role.User;
        await _contextModel.SaveChangesAsync();
        return customer;
    }
}