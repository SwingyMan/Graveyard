using Graveyard_Backend.DTOs;

namespace Graveyard_Backend.IServices;

public interface IItemService
{
    public Task<Models.Item> addItem(Item item);
    public Task removeItem(int ItemId);
    public Task<Models.Item> updateItem(int ItemId, Item item);
    public Task<List<Models.Item>> getItems(int page);
    public Task<Models.Item> getItemById(int id);
    public Task<Models.Item> changeQuantity(int id, int quantity);
}