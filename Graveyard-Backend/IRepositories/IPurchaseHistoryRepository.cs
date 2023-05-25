using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IPurchaseHistoryRepository : ICRUDRepository<PurchaseHistory>
{
    public Task<PurchaseHistory> showHistory(int CustomerId);
}