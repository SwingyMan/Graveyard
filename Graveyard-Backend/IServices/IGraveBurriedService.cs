using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface IGraveBurriedService
{
    public Task<GraveBurried> addBurriedToGrave(int burriedId, int graveId);
    public Task removeBurriedFromGrave(int burriedId, int graveId);
}