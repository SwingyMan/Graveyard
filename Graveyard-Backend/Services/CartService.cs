using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class CartService : ICartService
{
    private readonly CartRepository _cartRepository;

    public CartService(CartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Cart> addItemToCart(int CustomerId, int ItemId, int GraveId, int Quantity)
    {
        return await _cartRepository.AddItemToCart(CustomerId, ItemId, GraveId, Quantity);
    }

    public async Task removeItemFromCart(int CustomerId, int itemId, int GraveId)
    {
        await _cartRepository.RemoveItemFromCart(CustomerId, itemId, GraveId);
    }

    public async Task<List<Cart>> showCart(int CustomerId)
    {
        return await _cartRepository.showCart(CustomerId);
    }

    public async Task removeAllItemsFromCart(int CustomerId)
    {
        await _cartRepository.removeAllItemsFromCart(CustomerId);
    }
}