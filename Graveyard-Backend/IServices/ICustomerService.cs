﻿using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface ICustomerService
{
    public Task<Token> CreateUser(Register register, HttpClient _httpclient);
    public Task<Token> LoginUser(Login loginDTO, HttpClient httpClient);
    public Task<Customer> UpdateUser(int id, Edit editDTO);
    public Task DeleteUser(int id);
    public Task<Customer> GetUser(int id);
    public Task<List<Customer>> GetAll(int page);
}