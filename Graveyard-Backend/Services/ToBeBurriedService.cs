using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class ToBeBurriedService : IToBeBurriedService
{
    private readonly ToBeBuriedRepository _toBeBuriedRepository;

    public ToBeBurriedService(ToBeBuriedRepository toBeBuriedRepository)
    {
        _toBeBuriedRepository = toBeBuriedRepository;
    }
    public async Task<ToBeBurried> addBurried(int burriedId, DateTime burrial_date)
    {
        return await _toBeBuriedRepository.addBurried(burriedId, burrial_date);
    }

    public async Task<ToBeBurried> editBurried(int toBeBurriedId, DateTime burial_date)
    {
        return await _toBeBuriedRepository.editDate(toBeBurriedId, burial_date);
    }

    public async Task removeToBeBurried(int toBeBurriedId)
    {
        await _toBeBuriedRepository.deleteByID(toBeBurriedId);
    }

    public async Task<List<ToBeBurried>> listburried(int page)
    {
        return await _toBeBuriedRepository.ListAll(page);
    }

    public  async Task<ToBeBurried> getBurriedById(int id)
    {
        return await _toBeBuriedRepository.getByID(id);
    }
}