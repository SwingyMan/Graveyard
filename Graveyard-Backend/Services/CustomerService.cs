using System.Net.Http.Headers;
using Graveyard_Backend.DTOs;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class CustomerService : IAccountService
{
    private readonly contextModel _contextModel;
    private readonly CustomerRepository _customerRepository;

    public CustomerService(contextModel contextModel)
    {
        _contextModel = contextModel;
        _customerRepository = new CustomerRepository(_contextModel);
    }

    public async Task<string> CreateUser(Register registerForm, HttpClient _httpClient)
    {
        var customer = new Customer(registerForm.FirstName, registerForm.LastName, registerForm.email,
            registerForm.password);
        var testEmail = await _customerRepository.getByEmail(registerForm.email);
        if (testEmail != null) return null;

        {
            await _customerRepository.add(customer);
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