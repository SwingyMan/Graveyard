using Graveyard_Backend.IRepositories;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Services;

public class BurriedService : IBurriedService
{
    private readonly IBurriedRepository _burriedRepository;

    public BurriedService(IBurriedRepository burriedRepository)
    {
        _burriedRepository = burriedRepository;
    }

    public async Task<Burried> addBurried(DTOs.Burried burried)
    {
        var dead = new Burried(burried.name, burried.lastname, burried.date_of_birth, burried.date_of_death);
        await _burriedRepository.add(dead);
        return dead;
    }

    public async Task deleteBurried(int BurriedId)
    {
        await _burriedRepository.deleteByID(BurriedId);
    }

    public async Task<List<Burried>> getAll(int page)
    {
        return await _burriedRepository.ListAll(page);
    }

    public async Task<Burried> getById(int Burriedid)
    {
        return await _burriedRepository.getByID(Burriedid);
    }

    public async Task<Burried> editById(int BurriedId, DTOs.Burried burried)
    {
        var dead = new Burried(burried.name, burried.lastname, burried.date_of_birth, burried.date_of_death);
        return await _burriedRepository.UpdateById(BurriedId, dead);
    }
}