using Graveyard.Models;
using Graveyard_Backend.Interfaces;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserRepository _userRepository;
        private readonly contextModel _contextModel;
        public AccountService(contextModel contextModel)
        {
            _contextModel = contextModel;
            _userRepository = new UserRepository(_contextModel);
        }

        public Task<Customer> CreateUser(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSelf()
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task LoginUser(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateUser(int id, EditDTO editDTO)
        {
            throw new NotImplementedException();
        }
    }
}
