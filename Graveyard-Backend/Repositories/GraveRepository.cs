using Graveyard.Models;
using Graveyard_Backend.Interfaces;

namespace Graveyard_Backend.Repositories
{
    public class GraveRepository : IGraveRepository
    {
        public Task<Grave> add(Grave entity)
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

        public Task<Grave> getByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Grave>> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<Grave> updateByID(int id, Grave entity)
        {
            throw new NotImplementedException();
        }
    }
}
