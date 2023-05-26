using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories;

public class ToBeBuriedRepository : CRUDRepository<ToBeBurried>, IToBeBurriedRepository
{
    private ContextModel _contextModel;

    public ToBeBuriedRepository(ContextModel model)
    {
        _contextModel = model;
    }

    public async Task<ToBeBurried> addBurried(int burriedId, DateTime burialTime)
    {
        var burried = await _contextModel.burried.FirstOrDefaultAsync(x => x.BurriedId == burriedId);
        if (burried == null)
            return null;
        var tobeburried = new ToBeBurried(burried, burialTime);
        await _contextModel.AddAsync(tobeburried);
        await _contextModel.SaveChangesAsync();
        return tobeburried;
    }
    public async Task<ToBeBurried> editDate(int toBeBurriedId, DateTime burialTime)
    {
        var burried = await _contextModel.burials.FirstOrDefaultAsync(x => x.ToBeBurriedId == toBeBurriedId);
        if (burried == null)
            return null;
        burried.burial_date = burialTime;
        await _contextModel.SaveChangesAsync();
        return burried;
    }
}