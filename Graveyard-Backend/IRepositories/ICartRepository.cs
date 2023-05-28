using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface ICartRepository : ICRUDRepository<Cart>
{
	public Task<Cart> AddItemToCart(int CustomerId, int ItemId,int GraveId,int Quantity);
	public Task RemoveItemFromCart(int CustomerId, int ItemId,int GraveId);
	public Task removeAllItemsFromCart(int CustomerId);
	public Task<List<Cart>> showCart(int CustomerId);
}