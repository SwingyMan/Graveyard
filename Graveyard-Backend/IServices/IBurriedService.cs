using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface IBurriedService
{
    public Task<Burried> addBurried(DTOs.Burried burried);
    public Task deleteBurried(int BurriedId);
    public Task<List<Burried>> getAll(int page);
    public Task<Burried> getById(int Burriedid);
    public Task<Burried> editById(int BurriedId, DTOs.Burried burried);
    
    
    public Task<List<Burried>> GetToBeBurried();
}