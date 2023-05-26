using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices;

public interface IGraveService
{
    public Task<Grave> add(DTOs.Grave grave);
    public Task<Grave> edit(int id,DTOs.Grave grave);
    public Task delete(int id);
    public Task<List<Grave>> list(int page);
    public Task<Grave> getById(int id);
    public Task<Grave> extendGrave(int id);
}