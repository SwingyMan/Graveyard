using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IToBeBurriedRepository : ICRUDRepository<ToBeBurried>
{
    public Task<ToBeBurried> addNewBurried(int burriedId, DateTime burialTime);
}