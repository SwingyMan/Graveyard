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
    }
}
