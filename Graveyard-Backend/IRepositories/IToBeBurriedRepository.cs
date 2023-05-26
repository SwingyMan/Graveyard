using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IToBeBurriedRepository : ICRUDRepository<ToBeBurried>
{
    Task<ToBeBurried> addBurried(int burriedId, DateTime burialTime);
    public Task<ToBeBurried> editDate(int toBeBurriedId, DateTime burialTime);
}