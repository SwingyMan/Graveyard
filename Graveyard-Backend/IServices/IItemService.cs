using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface IItemService
{
    public Task<Item> addItem(DTOs.Item item);
    public Task removeItem(int ItemId);
    public Task<Item> updateItem(int ItemId, DTOs.Item item);
    public Task<List<Item>> getItems(int page);
    public Task<Item> getItemById(int id);
    public Task<Item> changeQuantity(int id, int quantity);
}