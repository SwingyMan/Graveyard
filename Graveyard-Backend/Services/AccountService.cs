using System.Net.Http.Headers;
using Graveyard_Backend.DTOs;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard.Models;

namespace Graveyard_Backend.Services;

public class AccountService : IAccountService
{
    private readonly contextModel _contextModel;
    private readonly UserRepository _userRepository;

    public AccountService(contextModel contextModel)
    {
        _contextModel = contextModel;
        _userRepository = new UserRepository(_contextModel);
    }

    public async Task<String> CreateUser(Register registerForm,HttpClient _httpClient)
    {
        var customer = new Customer(registerForm.FirstName, registerForm.LastName, registerForm.email,
            registerForm.password);
        var testEmail = await _userRepository.getByEmail(registerForm.email);
        if (testEmail != null)
        {
            return null;
        }

        {
            await _userRepository.add(customer);
            var x = JwtAuth.GenerateToken(customer);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", x);
            return x;
        }
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

    public Task<string> LoginUser(Login loginDTO)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> UpdateUser(int id, Edit editDTO)
    {
        throw new NotImplementedException();
    }
}