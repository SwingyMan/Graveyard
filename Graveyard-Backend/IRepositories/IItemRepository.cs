using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IItemRepository : ICRUDRepository<Item>
{
    public Task<Item> IncreaseQuantity(int quantity, int ItemId);
    public Task<Item> DecreaseQuantity(int quantity, int ItemId);
}