using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class GravediggerService : IGravediggerService
{
    private readonly GravediggerRepository _gravediggerRepository;

    public GravediggerService(GravediggerRepository gravediggerRepository)
    {
        _gravediggerRepository = gravediggerRepository;
    }

    public async Task<List<Gravedigger>> getAll(int page)
    {
        return await _gravediggerRepository.ListAll(page);
    }

    public async Task<Gravedigger> getById(int id)
    {
        return await _gravediggerRepository.getByID(id);
    }

    public async Task<Gravedigger> addGravedigger(DTOs.Gravedigger gravedigger)
    {
        var model = new Gravedigger(gravedigger.FirstName, gravedigger.LastName);
        return await _gravediggerRepository.add(model);
    }

    public async Task<Gravedigger> updateGravedigger(int id, DTOs.Gravedigger gravedigger)
    {
        var model = new Gravedigger(gravedigger.FirstName, gravedigger.LastName);
        return await _gravediggerRepository.updateByID(id, model);
    }

    public async Task removeGravedigger(int id)
    {
        await _gravediggerRepository.deleteByID(id);
    }
}