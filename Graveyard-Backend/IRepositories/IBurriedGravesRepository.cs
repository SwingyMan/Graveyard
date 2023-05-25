using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IBurriedGravesRepository : ICRUDRepository<BurriedGrave>
{
    public Task<BurriedGrave> addBurriedToGrave(int BurriedId, int GraveId);
    public Task<BurriedGrave> removeBurriedFromGrave(int BurriedId,int GraveId);
}