using Graveyard_Backend.IRepositories;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Burried = Graveyard_Backend.DTOs.Burried;

namespace Graveyard_Backend.Services;

public class GraveBurriedService : IGraveBurriedService
{
    private readonly IGraveBurriedRepository _graveBurriedRepository;
    private readonly IBurriedRepository _burriedRepository;
    public GraveBurriedService(IGraveBurriedRepository graveBurriedRepository,IBurriedRepository burriedRepository)
    {
        _graveBurriedRepository = graveBurriedRepository;
        _burriedRepository = burriedRepository;
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

    public async IAsyncEnumerable<Models.Burried> getBurriedFromGrave(int GraveId)
    {
        foreach (var burried in await _graveBurriedRepository.getBurriedFromGrave(GraveId))
        {
            yield return await _burriedRepository.getByID(burried.BurriedId);
        }

        
    }
}