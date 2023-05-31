using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IPurchaseHistoryRepository : ICRUDRepository<PurchaseHistory>
{
    public Task<List<PurchaseHistory>> showHistory(int CustomerId);
    public Task<PurchaseHistory> addNewPurchaseHistory(List<Cart> carts, int customerid, decimal totalPRice);
    public Task<PurchaseHistory> changeStatus(int PurchaseId);
}