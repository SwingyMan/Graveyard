using Graveyard.Models;
using Graveyard_Backend.Interfaces;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly contextModel _contextModel;
        public UserRepository(contextModel contextModel) {
            _contextModel = contextModel;
        }
        public async Task<bool> deleteAll()
        {
            if(_contextModel.customer == null)
                return false;
            foreach(var item in _contextModel.customer)
            {
                _contextModel.customer.Remove(item);
            }
            _contextModel.SaveChanges();
            return true;
        }

        public async Task<bool> deleteByID(int id)
        {
            var customer = _contextModel.customer.FirstOrDefault(x => x.CustomerID == id);
            if (customer == null)
                return false;
            _contextModel.Remove(customer);
            await _contextModel.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> getByID(int id)
        {
            var customer = _contextModel.customer.FirstOrDefault(x=> x.CustomerID == id);
            if (customer == null)
                return null;
            return customer;
        }

        public async Task<List<Customer>> ListAll()
        {
            return await _contextModel.customer.ToListAsync();
        }

        public async Task<Customer> updateByID(int id, Customer entity)
        {
            var customer = await _contextModel.customer.FirstOrDefaultAsync(x => x.CustomerID == id);
            customer.Name = entity.Name;
            customer.Email = entity.Email;
            customer.Owned_role = entity.Owned_role;
            customer.LastName = entity.LastName;
            customer.Password = entity.Password;
            await _contextModel.SaveChangesAsync();
            return customer;
            
        }

        public async Task<Customer> add(Customer entity)
        {
            await _contextModel.customer.AddAsync(entity);
            await _contextModel.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer> getByEmail(string email)
        {
             var account =await _contextModel.customer.FirstOrDefaultAsync(x=> x.Equals(email));
            if (account == null)
                return null;
            return account;
        }

        public async Task<Customer> getByEmailAndPassword(string email, string password)
        {
            var account = await _contextModel.customer.FirstOrDefaultAsync(x => x.Equals(email) && x.Password==password);
            if (account == null)
                return null;
            return account;
        }
    }
}
