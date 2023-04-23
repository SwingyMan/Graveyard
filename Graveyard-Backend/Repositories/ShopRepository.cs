using Graveyard.Models;
using Graveyard_Backend.Interfaces;

namespace Graveyard_Backend.Repositories
{
    public class ShopRepository : IShopHistoryRepository
    {
        public Task<shopHistory> add(shopHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> deleteAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> deleteByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<shopHistory> getByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<shopHistory>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<shopHistory> updateByID(int id, shopHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}
