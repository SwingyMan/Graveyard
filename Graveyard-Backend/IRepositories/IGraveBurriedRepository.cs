using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IGraveBurriedRepository : ICRUDRepository<GraveBurried>
{
    public Task<GraveBurried> addBurriedToGrave(int BurriedId, int GraveId, int gravediggerId, DateTime burialDate);
    public Task removeBurriedFromGrave(int BurriedId, int GraveId);
    public Task<List<GraveBurried>> getBurriedFromGrave(int GraveId);
}