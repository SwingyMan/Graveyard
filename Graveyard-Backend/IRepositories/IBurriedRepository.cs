using Graveyard_Backend.Models;

namespace Graveyard_Backend.IRepositories;

public interface IBurriedRepository : ICRUDRepository<Burried>
{
    public Task<Burried> UpdateById(int id, DTOs.Burried burriedDto);

}