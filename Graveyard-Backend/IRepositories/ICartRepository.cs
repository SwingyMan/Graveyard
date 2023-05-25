using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface ICartRepository : ICRUDRepository<Cart>
{
	public Task<Cart> AddItemToCart(int CustomerId, int ItemId,int GraveId,int Quantity);
	public Task<Cart> RemoveItemFromCart(int CustomerId, int ItemId,int GraveId,int Quantity);
	public Task<PurchaseHistory> Submit(int CustomerId);
}