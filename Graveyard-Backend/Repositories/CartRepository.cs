using Graveyard_Backend.Models;
using Graveyard_Backend.IRepositories;

namespace Graveyard_Backend.Repositories;

public class CartRepository : CRUDRepository<Cart>, ICartRepository
{
    private contextModel _contextModel;

    public CartRepository(contextModel contextModel)
    {
        _contextModel = contextModel;
    }
    public Task<Cart> AddItemToCart(int CustomerId, int ItemId, int GraveId, int Quantity)
    {
        throw new NotImplementedException();
    }

    public Task<Cart> RemoveItemFromCart(int CustomerId, int ItemId, int GraveId, int Quantity)
    {
        throw new NotImplementedException();
    }

    public Task<PurchaseHistory> Submit(int Customerid)
    {
        throw new NotImplementedException();
    }
}