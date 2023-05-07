using Graveyard.Models;
using Graveyard_Backend.Models;

namespace Graveyard_Backend.IServices
{
    public interface IGraveService
    {
        public Task<Grave> ExtendGrave(int id);
        public Task<Grave> AddGrave(GraveDTO dto);
        public Task RemoveGrave(int id);
        public Task<Grave> UpdateGrave(int id,GraveDTO dto);
        public Task<Grave> GetGrave(int id);
        public Task<List<Grave>> GetGraveList(int id);
        public Task<ToBeBurried> AddToBeBurried(ToBeBurried toBeBurried);
        public Task<ToBeBurried> GetToBeBurried(int id);
        public Task<List<ToBeBurried>> GetToBeBurriedList(int id);
        public Task DeleteToBeBurried(int id);
        public Task<ToBeBurried> UpdateToBeBurried(ToBeBurried toBeBurried);
    }
}
