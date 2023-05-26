using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class GraveBurriedService : IGraveBurriedService
{
    private readonly GraveBurriedRepository _graveBurriedRepository;

    public GraveBurriedService(GraveBurriedRepository graveBurriedRepository)
    {
        _graveBurriedRepository = graveBurriedRepository;
    }
    public async Task<GraveBurried> addBurriedToGrave(int burriedId, int graveId)
    {
        return await _graveBurriedRepository.addBurriedToGrave(burriedId, graveId);
    }

    public async Task removeBurriedFromGrave(int burriedId, int graveId)
    {
        await _graveBurriedRepository.removeBurriedFromGrave(burriedId, graveId);
    }
}