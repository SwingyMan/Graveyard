using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Graveyard_Backend.DTOs;
using Graveyard_Backend.IRepositories;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<string> CreateUser(Register registerForm, HttpClient _httpClient)
    {
        var pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        var regex = new Regex(pattern);
        var customer = new Customer(registerForm.FirstName, registerForm.LastName, registerForm.email,
            registerForm.password);
        var testEmail = await _customerRepository.getByEmail(registerForm.email);
        if (testEmail != null || !regex.IsMatch(registerForm.email)) return null;

        {
            await _customerRepository.add(customer);
            var x = JwtAuth.GenerateToken(customer);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", x);
            return x;
        }
    }

    public async Task DeleteUser(int id)
    {
        await _customerRepository.deleteByID(id);
    }

    public async Task<List<Customer>> GetAll(int page)
    {
        return await _customerRepository.ListAll(page);
    }

    public async Task<Customer> GetUser(int id)
    {
        return await _customerRepository.getByID(id);
    }

    public async Task<string> LoginUser(Login loginDTO, HttpClient _httpClient)
    {
        loginDTO.hashPassword();
        var account = await _customerRepository.getByEmailAndPassword(loginDTO.email, loginDTO.password);
        if (account == null) return string.Empty;

        {
            var x = JwtAuth.GenerateToken(account);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", x);
            return x;
        }
    }

    public async Task<Customer> UpdateUser(int id, Edit editDTO)
    {
        return await _customerRepository.updateByID(id, editDTO);
    }
}