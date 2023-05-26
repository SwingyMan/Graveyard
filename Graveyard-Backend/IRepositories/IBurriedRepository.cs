using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;
using Burried = Graveyard_Backend.DTOs.Burried;

namespace Graveyard_Backend.IRepositories;

public interface IBurriedRepository : ICRUDRepository<Models.Burried>
{
	public Task<Models.Burried> UpdateById(int id, Burried burriedDto);
}