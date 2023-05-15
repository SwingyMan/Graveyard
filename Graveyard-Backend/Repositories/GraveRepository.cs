using Graveyard_Backend.Interfaces;
using Graveyard_Backend.Models;
using Graveyard.Models;

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
        var grave = _contextModel.grave.FirstOrDefault(x => x.GraveID == id);
        grave.validUntil.AddYears(5);
        await _contextModel.SaveChangesAsync();
        return grave;
    }

    public Task<Grave> UpdateById(int id, DTOs.Grave grave)
    {
        throw new NotImplementedException();
    }
}