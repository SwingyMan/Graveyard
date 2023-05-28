﻿using Graveyard_Backend.Models;
using Graveyard_Backend.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories;

public class CartRepository : CRUDRepository<Cart>, ICartRepository
{
    private ContextModel _contextModel;
    public CartRepository(ContextModel contextModel)
    {
        _contextModel = contextModel;
    }
    public async Task<Cart> AddItemToCart(int CustomerId, int ItemId, int GraveId, int Quantity)
    {
        var customer = await _contextModel.customer.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
        var item = await _contextModel.item.FirstOrDefaultAsync(x => x.ItemId == ItemId);
        var grave = await _contextModel.grave.FirstOrDefaultAsync(x => x.GraveId == GraveId);
        var cart = new Cart(customer, item, grave, Quantity);
        await _contextModel.carts.AddAsync(cart);
        await _contextModel.SaveChangesAsync();
        return cart;
    }

    public async Task RemoveItemFromCart(int CustomerId, int ItemId, int GraveId)
    {
        var cart = await _contextModel.carts.FirstOrDefaultAsync(x =>
            x.CustomerId == CustomerId && x.ItemId == ItemId && x.GraveId == GraveId); 
        _contextModel.Remove(cart);
        await _contextModel.SaveChangesAsync();
    }

    public async Task removeAllItemsFromCart(int CustomerId)
    {
        var carts = _contextModel.carts.Where(x =>
            x.CustomerId == CustomerId);
        foreach (var cart in carts)
        {
            _contextModel.Remove(cart);
        }

        await _contextModel.SaveChangesAsync();
    }

    public async Task<List<Cart>> showCart(int CustomerId)
    {
        return await _contextModel.carts.Where(x => x.CustomerId == CustomerId).ToListAsync();
    }
}