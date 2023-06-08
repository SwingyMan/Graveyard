using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories;

public class PurchaseHistoryRepository : CRUDRepository<PurchaseHistory>, IPurchaseHistoryRepository
{
    private readonly ContextModel _contextModel;

    public PurchaseHistoryRepository(ContextModel contextModel)
    {
        _contextModel = contextModel;
    }

    public async Task<List<PurchaseHistory>> showHistory(int CustomerId)
    {
        return await _contextModel.PurchaseHistory.Where(x => x.CustomerId == CustomerId).ToListAsync();
    }

    public async Task<PurchaseHistory> addNewPurchaseHistory(List<Cart> carts, int customerid, decimal totalPrice)
    {
        var customer = await _contextModel.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerid);
        var purchase = new PurchaseHistory(customer, carts, totalPrice);
        await _contextModel.PurchaseHistory.AddAsync(purchase);
        await _contextModel.SaveChangesAsync();
        return purchase;
    }

    public async Task<PurchaseHistory> changeStatus(int PurchaseId)
    {
        var purchase = await _contextModel.PurchaseHistory.FirstOrDefaultAsync(x => x.ShopHistoryId == PurchaseId);
        purchase.Status = PurchaseStatus.Done;
        await _contextModel.SaveChangesAsync();
        return purchase;
    }
}