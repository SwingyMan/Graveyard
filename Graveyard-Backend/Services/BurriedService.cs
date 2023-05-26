using Graveyard_Backend.DTOs;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class BurriedService : IBurriedService
{
    private readonly BurriedRepository _burriedRepository;

    public BurriedService(BurriedRepository burriedRepository)
    {
        _burriedRepository = burriedRepository;
    }

    public async Task<Models.Burried> addBurried(Burried burried)
    {
        var dead = new Models.Burried(burried.name, burried.lastname, burried.date_of_birth, burried.date_of_death);
        await _burriedRepository.add(dead);
        return dead;
    }

    public async Task deleteBurried(int BurriedId)
    {
       await _burriedRepository.deleteByID(BurriedId);
    }

    public async Task<List<Models.Burried>> getAll(int page)
    {
        return await _burriedRepository.ListAll(page);
    }

    public async Task<Models.Burried> getById(int Burriedid)
    {
        return await _burriedRepository.getByID(Burriedid);
    }

    public async Task<Models.Burried> editById(int BurriedId, Burried burried)
    {
        var dead = new Models.Burried(burried.name, burried.lastname, burried.date_of_birth, burried.date_of_death);
        return await _burriedRepository.updateByID(BurriedId, dead);
    }
}