using Graveyard.Models;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Interfaces
{
    public interface IBurriedRepository : ICRUDRepository<Burried>
    {
        public Task<Burried> UpdateById(int id,BurialDTO burialDTO);
    }
}
