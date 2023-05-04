using Graveyard.Models;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Interfaces
{
    public interface IGraveRepository : ICRUDRepository<Grave>
    {
        public Task<Grave> UpdateById(int id, GraveDTO grave);
        public Task<Grave> ExtendDate(int id);
    }
}
