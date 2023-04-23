using Graveyard.Models;
using Graveyard_Backend.Interfaces;

namespace Graveyard_Backend.Repositories
{
    public class BurriedRepository : IBurriedRepository
    {
        public Task<Burried> add(Burried entity)
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

        public Task<Burried> getByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Burried>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<Burried> updateByID(int id, Burried entity)
        {
            throw new NotImplementedException();
        }
    }
}
