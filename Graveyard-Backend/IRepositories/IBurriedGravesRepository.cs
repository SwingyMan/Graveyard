using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IBurriedGravesRepository : ICRUDRepository<GraveBurried>
{
    public Task<GraveBurried> addBurriedToGrave(int BurriedId, int GraveId);
    public Task<GraveBurried> removeBurriedFromGrave(int BurriedId, int GraveId);
}