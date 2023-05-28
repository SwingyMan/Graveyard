using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IItemRepository : ICRUDRepository<Item>
{
    public Task<Item> IncreaseQuantity(int ItemId);
    public Task<Item> DecreaseQuantity(int ItemId);
    public Task<Item> ChangeQuantity(int quantity, int ItemId);
}