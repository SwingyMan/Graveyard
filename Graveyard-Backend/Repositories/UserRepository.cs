using Graveyard.Models;
using Graveyard_Backend.Interfaces;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories
{
    public class UserRepository : CRUDRepository<Customer>,IUserRepository
    {
        private readonly contextModel _contextModel;
        public UserRepository(contextModel contextModel)
        {
            _contextModel = contextModel;
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

        public async Task<Customer> updateByID(int id, EditDTO customer)
        {
            var original = _contextModel.customer.FirstOrDefault(x => x.CustomerID == id);
            if (!String.IsNullOrEmpty(customer.FirstName))
                original.Name = customer.FirstName;
            if(!String.IsNullOrEmpty(customer.LastName))
                original.LastName = customer.LastName;
            if (!String.IsNullOrEmpty(customer.email))
                original.Email = customer.email;
            if(!String.IsNullOrEmpty(customer.password))
                original.Password = customer.password;
            if(!String.IsNullOrEmpty(customer.Owned_role))
                original.Owned_role = customer.Owned_role;
            await _contextModel.SaveChangesAsync();
            return original;
        }
    }
}
