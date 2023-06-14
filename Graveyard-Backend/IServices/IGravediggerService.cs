using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface IGravediggerService
{
    public Task<List<Gravedigger>> getAll(int page);
    public Task<Gravedigger> getById(int id);
    public Task<Gravedigger> addGravedigger(DTOs.Gravedigger gravedigger);
    public Task<Gravedigger> updateGravedigger(int id, DTOs.Gravedigger gravedigger);
    public Task removeGravedigger(int id);
}