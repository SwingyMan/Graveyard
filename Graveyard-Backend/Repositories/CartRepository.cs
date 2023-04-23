using Graveyard.Models;
using Graveyard_Backend.Interfaces;

namespace Graveyard_Backend.Repositories
{
    public class CartRepository : ICartRepository
    {
        public Task<Cart> add(Cart entity)
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

        public Task<Cart> getByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> updateByID(int id, Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
