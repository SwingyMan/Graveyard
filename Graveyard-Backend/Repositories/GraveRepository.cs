using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories;

public class GraveRepository : CRUDRepository<Grave>, IGraveRepository
{
    private readonly ContextModel _contextModel;

    public GraveRepository(ContextModel contextModel)
    {
        _contextModel = contextModel;
    }

    public async Task<Grave> extendDate(int id)
    {
        var grave = await _contextModel.grave.FirstOrDefaultAsync(x => x.GraveId == id);
        grave.validUntil.AddYears(5);
        grave.status = GraveStatus.Paid;
        await _contextModel.SaveChangesAsync();
        return grave;
    }
}