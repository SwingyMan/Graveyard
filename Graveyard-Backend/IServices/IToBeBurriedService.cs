using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface IToBeBurriedService
{
    public Task<ToBeBurried> addBurried(int burriedId, DateTime burrial_date);
    public Task<ToBeBurried> editBurried(int toBeBurriedId, DateTime burial_date);
    public Task removeToBeBurried(int toBeBurriedId);
    public Task<List<ToBeBurried>> listburried(int page);
    public Task<ToBeBurried> getBurriedById(int id);
}