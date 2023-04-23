using Graveyard.Models;
using Graveyard_Backend.Interfaces;

namespace Graveyard_Backend.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public Task<Item> add(Item entity)
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

        public Task<Item> getByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<Item> updateByID(int id, Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
