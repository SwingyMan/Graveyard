using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Repositories;

public class GraveRepository : CRUDRepository<Grave>, IGraveRepository
{
    private readonly contextModel _contextModel;

    public GraveRepository(contextModel contextModel)
    {
        _contextModel = contextModel;
    }

    public async Task<Grave> ExtendDate(int id)
    {
        var grave = _contextModel.grave.FirstOrDefault(x => x.GraveId == id);
        grave.validUntil.AddYears(5);
        await _contextModel.SaveChangesAsync();
        return grave;
    }

    public Task<Grave> ChangeStatus(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Grave> UpdateById(int id, DTOs.Grave grave)
    {
        throw new NotImplementedException();
    }
}