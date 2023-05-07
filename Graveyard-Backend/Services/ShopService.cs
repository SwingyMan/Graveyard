using Graveyard.Models;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services
{
    public class ShopService : IShopService
    {
        private readonly contextModel _contextModel;
        private readonly CartRepository _cartRepository;
        private readonly ItemRepository _itemRepository;
        public ShopService(contextModel contextModel)
        {
            _contextModel = contextModel;
            _cartRepository = new CartRepository(_contextModel);
            _itemRepository = new ItemRepository(_contextModel);
        }

        public Task<Item> AddItem(ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> BuyItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> DeleteItemFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCart(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> ListItems()
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateItem(int id, ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
