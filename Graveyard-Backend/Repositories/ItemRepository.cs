using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Repositories;

public class ItemRepository : CRUDRepository<Item>, IItemRepository
{
    private contextModel _contextModel;

    public ItemRepository(contextModel contextModel)
    {
        _contextModel = contextModel;
    }

    public Task<Item> IncreaseQuantity(int quantity, int ItemId)
    {
        throw new NotImplementedException();
    }

    public Task<Item> DecreaseQuantity(int quantity, int ItemId)
    {
        throw new NotImplementedException();
    }
}