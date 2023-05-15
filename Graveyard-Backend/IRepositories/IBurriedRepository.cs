using Graveyard_Backend.DTOs;
using Graveyard_Backend.Models;
using Graveyard.Models;

namespace Graveyard_Backend.Interfaces;

public interface IBurriedRepository : ICRUDRepository<Burried>
{
    public Task<Burried> UpdateById(int id, Burial burialDTO);
}