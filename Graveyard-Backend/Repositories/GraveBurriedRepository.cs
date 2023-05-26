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
    public async Task<GraveBurried> addBurriedToGrave(int BurriedId, int GraveId)
    {
        var burried = await _contextModel.burried.FirstOrDefaultAsync(x => x.BurriedId == BurriedId);
        var grave = await _contextModel.grave.FirstOrDefaultAsync(x => x.GraveId == GraveId);
        var graveburried = new GraveBurried(burried, grave);
        await _contextModel.graveBurried.AddAsync(graveburried);
        await _contextModel.SaveChangesAsync();
        return graveburried;
    }

    public async Task removeBurriedFromGrave(int BurriedId, int GraveId)
    {
        var burried = await _contextModel.burried.FirstOrDefaultAsync(x => x.BurriedId == BurriedId);
        var grave = await _contextModel.grave.FirstOrDefaultAsync(x => x.GraveId == GraveId);
        var x = await _contextModel.graveBurried.FirstOrDefaultAsync(x => x.burried == burried && x.grave == grave); 
        _contextModel.graveBurried.Remove(x);
        await _contextModel.SaveChangesAsync();
    }
}