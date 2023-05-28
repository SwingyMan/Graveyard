using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface ICartService
{
    public Task<Cart> addItemToCart(int CustomerId, int ItemId, int GraveId,int quantity);
    public Task removeItemFromCart(int CustomerId, int itemId, int GraveId);
    public Task<List<Cart>> showCart(int CustomerId);
    public Task removeAllItemsFromCart(int CustomerId);
}