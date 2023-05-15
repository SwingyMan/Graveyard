﻿using Graveyard_Backend.Models;
using Graveyard.Models;

namespace Graveyard_Backend.IServices;

public interface IShopService
{
    public Task<List<Item>> ListItems();
    public Task<Item> GetItem(int id);
    public Task<List<Item>> BuyItem(int id);
    public Task<Cart> GetCart(int id);
    public Task<Cart> DeleteItemFromCart(int id);
    public Task<Item> AddItem(DTOs.Item itemDTO);
    public Task<Item> UpdateItem(int id, DTOs.Item itemDTO);
    public Task<Item> DeleteItem(int id);
}