using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.Repositories;

public class ToBeBuriedRepository : CRUDRepository<ToBeBurried>, IToBeBurriedRepository
{
    private contextModel _contextModel;

    public ToBeBuriedRepository(contextModel model)
    {
        _contextModel = model;
    }

    public Task<ToBeBurried> addNewBurried(int burriedId, DateTime burialTime)
    {
        throw new NotImplementedException();
    }
}