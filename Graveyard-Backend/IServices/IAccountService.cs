using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;
using Graveyard.Models;

namespace Graveyard_Backend.IServices;

public interface IAccountService
{
    public Task<string> CreateUser(Register register,HttpClient _httpclient);
    public Task<string> LoginUser(Login loginDTO);
    public Task<Customer> UpdateUser(int id, Edit editDTO);
    public Task DeleteUser(int id);
    public Task<Customer> GetUser(int id);
    public Task DeleteSelf();
    public Task<List<Customer>> GetAll();
}