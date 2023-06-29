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

    public async Task<GraveBurried> addBurriedToGrave(int burriedId, int graveId, int gravediggerId)
    {
        return await _graveBurriedRepository.addBurriedToGrave(burriedId, graveId, gravediggerId);
    }

    public async Task removeBurriedFromGrave(int burriedId, int graveId)
    {
        await _graveBurriedRepository.removeBurriedFromGrave(burriedId, graveId);
    }

    public async Task<List<Models.Burried>> getBurriedFromGrave(int GraveId)
    {
        var x = await _graveBurriedRepository.getBurriedFromGrave(GraveId);
        return x.Select(x => x.Burried).ToList();


    }
}