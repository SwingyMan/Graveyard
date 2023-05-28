using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories;

public class ItemRepository : CRUDRepository<Item>, IItemRepository
{
    private ContextModel _contextModel;

    public ItemRepository(ContextModel contextModel)
    {
        _contextModel = contextModel;
    }

    public async Task<Item> IncreaseQuantity(int ItemId)
    {
        var x = await _contextModel.item.FirstOrDefaultAsync(x => x.ItemId == ItemId);
        x.Quantity += 1;
        await _contextModel.SaveChangesAsync();
        return x;
    }

    public async Task<Item> DecreaseQuantity(int ItemId)
    {
        var x = await _contextModel.item.FirstOrDefaultAsync(x => x.ItemId == ItemId);
        x.Quantity -= 1;
        await _contextModel.SaveChangesAsync();
        return x;
    }

    public async Task<Item> ChangeQuantity(int quantity, int ItemId)
    {
        var x = await _contextModel.item.FirstOrDefaultAsync(x => x.ItemId == ItemId);
        x.Quantity = quantity;
        await _contextModel.SaveChangesAsync();
        return x;
    }
}