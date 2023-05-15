using Graveyard_Backend.Interfaces;
using Graveyard.Models;

namespace Graveyard_Backend.Repositories;

public class ItemRepository : CRUDRepository<Item>, IItemRepository
{
    private contextModel _contextModel;

    public ItemRepository(contextModel contextModel)
    {
        _contextModel = contextModel;
    }
}