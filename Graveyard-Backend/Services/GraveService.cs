using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;

namespace Graveyard_Backend.Services;

public class GraveService : IGraveService
{
    private readonly contextModel _contextModel;
    private readonly GraveRepository _graveRepository;
    private readonly ToBeBuriedRepository _toBeBuriedRepository;

    public GraveService(contextModel contextModel)
    {
        _contextModel = contextModel;
        _graveRepository = new GraveRepository(contextModel);
        _toBeBuriedRepository = new ToBeBuriedRepository(contextModel);
    }

    public Task<Grave> AddGrave(DTOs.Grave dto)
    {
        throw new NotImplementedException();
    }

    public Task<ToBeBurried> AddToBeBurried(ToBeBurried toBeBurried)
    {
        throw new NotImplementedException();
    }

    public Task DeleteToBeBurried(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Grave> ExtendGrave(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Grave> GetGrave(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Grave>> GetGraveList(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ToBeBurried> GetToBeBurried(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToBeBurried>> GetToBeBurriedList(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveGrave(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Grave> UpdateGrave(int id, DTOs.Grave dto)
    {
        throw new NotImplementedException();
    }

    public Task<ToBeBurried> UpdateToBeBurried(ToBeBurried toBeBurried)
    {
        throw new NotImplementedException();
    }
}