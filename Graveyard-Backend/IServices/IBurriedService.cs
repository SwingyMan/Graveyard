using Graveyard_Backend.DTOs;

namespace Graveyard_Backend.IServices;

public interface IBurriedService
{
    public Task<Models.Burried> addBurried(Burried burried);
    public Task deleteBurried(int BurriedId);
    public Task<List<Models.Burried>> getAll(int page);
    public Task<Models.Burried> getById(int Burriedid);
    public Task<Models.Burried> editById(int BurriedId, Burried burried);
}