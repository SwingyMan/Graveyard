using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface IPurchaseHistoryService
{
    public Task<PurchaseHistory> submitCart(int CustomerId);
    public Task<List<PurchaseHistory>> getList(int CustomerId);
    public Task<PurchaseHistory> changeState(int PurchaseHistoryId);
}