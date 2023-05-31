using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class ItemService : IItemService
{
    private readonly ItemRepository _itemRepository;

    public ItemService(ItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Item> addItem(DTOs.Item item)
    {
        var itemm = new Item(item.name, item.description, item.kind, item.price, item.quantity, item.imageUrl);
        await _itemRepository.add(itemm);
        return itemm;
    }

    public async Task removeItem(int ItemId)
    {
        await _itemRepository.deleteByID(ItemId);
    }

    public async Task<Item> updateItem(int ItemId, DTOs.Item item)
    {
        var itemm = new Item(item.name, item.description, item.kind, item.price, item.quantity, item.imageUrl);
        await _itemRepository.updateByID(ItemId, itemm);
        return itemm;
    }

    public async Task<List<Item>> getItems(int page)
    {
        return await _itemRepository.ListAll(page);
    }

    public async Task<Item> getItemById(int id)
    {
        return await _itemRepository.getByID(id);
    }

    public async Task<Item> changeQuantity(int id, int quantity)
    {
        return await _itemRepository.ChangeQuantity(quantity, id);
    }
}