using Graveyard_Backend.Models;
using Graveyard.Models;

namespace Graveyard_Backend.Interfaces;

public interface IGraveRepository : ICRUDRepository<Grave>
{
    public Task<Grave> UpdateById(int id, DTOs.Grave grave);
    public Task<Grave> ExtendDate(int id);
}