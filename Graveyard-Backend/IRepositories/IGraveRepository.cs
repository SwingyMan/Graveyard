using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IGraveRepository : ICRUDRepository<Grave>
{
    public Task<Grave> extendDate(int GraveId);
}