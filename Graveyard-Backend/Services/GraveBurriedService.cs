using Graveyard_Backend.IRepositories;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Services;

public class GraveBurriedService : IGraveBurriedService
{
    private readonly IGraveBurriedRepository _graveBurriedRepository;

    public GraveBurriedService(IGraveBurriedRepository graveBurriedRepository)
    {
        _graveBurriedRepository = graveBurriedRepository;
    }

    public async Task<GraveBurried> addBurriedToGrave(int burriedId, int graveId, int gravediggerId,
        DateTime burialDate)
    {
        return await _graveBurriedRepository.addBurriedToGrave(burriedId, graveId, gravediggerId, burialDate);
    }

    public async Task removeBurriedFromGrave(int burriedId, int graveId)
    {
        await _graveBurriedRepository.removeBurriedFromGrave(burriedId, graveId);
    }
}