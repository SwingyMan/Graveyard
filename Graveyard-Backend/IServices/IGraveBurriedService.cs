using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface IGraveBurriedService
{
    public Task<GraveBurried> addBurriedToGrave(int burriedId, int graveId, int gravediggerId);
    public Task removeBurriedFromGrave(int burriedId, int graveId);
    public  Task<List<Models.Burried>> getBurriedFromGrave(int GraveId);
}