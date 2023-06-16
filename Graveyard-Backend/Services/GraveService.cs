using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class GraveService : IGraveService
{
    private readonly ContextModel _contextModel;
    private readonly GraveRepository _graveRepository;

    public GraveService(GraveRepository graveRepository)
    {
        _graveRepository = graveRepository;
    }


    public async Task<Grave> add(DTOs.Grave grave)
    {
        var checkExisting = await _graveRepository.findByXandY(grave.x, grave.y);
        if (checkExisting == null)
        {
            var gravee = new Grave(grave.x, grave.y);
            await _graveRepository.add(gravee);
            return gravee;
        }

        return null;
    }

    public async Task<Grave> edit(int id, DTOs.Grave grave)
    {
        var gravee = new Grave(grave.x, grave.y);
        await _graveRepository.updateByID(id, gravee);
        return gravee;
    }

    public async Task delete(int id)
    {
        await _graveRepository.deleteByID(id);
    }

    public async Task<List<Grave>> list(int page)
    {
        return await _graveRepository.ListAll(page);
    }

    public async Task<Grave> getById(int id)
    {
        return await _graveRepository.getByID(id);
    }

    public async Task<Grave> extendGrave(int id)
    {
        return await _graveRepository.extendDate(id);
    }
}