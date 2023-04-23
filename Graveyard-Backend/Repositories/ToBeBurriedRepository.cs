using Graveyard.Models;
using Graveyard_Backend.Interfaces;

namespace Graveyard_Backend.Repositories
{
    public class ToBeBurriedRepository : IToBeBurriedRepository
    {
        public Task<ToBeBurried> add(ToBeBurried entity)
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

        public Task<ToBeBurried> getByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToBeBurried>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<ToBeBurried> updateByID(int id, ToBeBurried entity)
        {
            throw new NotImplementedException();
        }
    }
}
