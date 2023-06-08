using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories;

public class GraveBurriedRepository : CRUDRepository<GraveBurried>, IGraveBurriedRepository
{
    private readonly ContextModel _contextModel;

    public GraveBurriedRepository(ContextModel contextModel)
    {
        _contextModel = contextModel;
    }

    public async Task<GraveBurried> addBurriedToGrave(int BurriedId, int GraveId, int gravediggerId,
        DateTime burialDate)
    {
        var gravedigger = await _contextModel.Gravediggers.FirstOrDefaultAsync(x => x.GravediggerId == gravediggerId);
        var burried = await _contextModel.Burried.FirstOrDefaultAsync(x => x.BurriedId == BurriedId);
        var grave = await _contextModel.Grave.FirstOrDefaultAsync(x => x.GraveId == GraveId);
        var graveburried = new GraveBurried(burried, grave, gravedigger, burialDate);
        await _contextModel.GraveBurried.AddAsync(graveburried);
        await _contextModel.SaveChangesAsync();
        return graveburried;
    }

    public async Task removeBurriedFromGrave(int BurriedId, int GraveId)
    {
        var burried = await _contextModel.Burried.FirstOrDefaultAsync(x => x.BurriedId == BurriedId);
        var grave = await _contextModel.Grave.FirstOrDefaultAsync(x => x.GraveId == GraveId);
        var x = await _contextModel.GraveBurried.FirstOrDefaultAsync(x => x.Burried == burried && x.Grave == grave);
        _contextModel.GraveBurried.Remove(x);
        await _contextModel.SaveChangesAsync();
    }
}