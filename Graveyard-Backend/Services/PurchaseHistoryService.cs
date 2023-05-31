using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class PurchaseHistoryService : IPurchaseHistoryService
{
    private readonly CartRepository _cartRepository;
    private readonly ItemRepository _itemRepository;
    private readonly PurchaseHistoryRepository _purchaseHistoryRepository;

    public PurchaseHistoryService(PurchaseHistoryRepository purchaseHistoryRepository, CartRepository cartRepository,
        ItemRepository itemRepository)
    {
        _cartRepository = cartRepository;
        _itemRepository = itemRepository;
        _purchaseHistoryRepository = purchaseHistoryRepository;
    }

    public async Task<PurchaseHistory> submitCart(int CustomerId)
    {
        decimal totalprice = 0;
        var carts = await _cartRepository.showCart(CustomerId);
        foreach (var cart in carts)
        {
            var item = await _itemRepository.getByID(cart.ItemId);
            if (item.Quantity < cart.Items.Quantity)
            {
                return null;
            }

            await _itemRepository.ChangeQuantity(item.Quantity - cart.Items.Quantity, cart.ItemId);
            totalprice += item.Price * cart.Quantity;
        }

        return await _purchaseHistoryRepository.addNewPurchaseHistory(carts, CustomerId, totalprice);
    }

    public async Task<List<PurchaseHistory>> getList(int CustomerId)
    {
        return await _purchaseHistoryRepository.showHistory(CustomerId);
    }

    public async Task<PurchaseHistory> changeState(int PurchaseHistoryId)
    {
        return await _purchaseHistoryRepository.changeStatus(PurchaseHistoryId);
    }
}