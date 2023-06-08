using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories;

public class BurriedRepository : CRUDRepository<Burried>, IBurriedRepository
{
    private readonly ContextModel _contextModel;

    public BurriedRepository(ContextModel contextModel)
    {
        _contextModel = contextModel;
    }

    public async Task<Burried> UpdateById(int id, DTOs.Burried burriedDto)
    {
        var burried = await _contextModel.Burried.FirstOrDefaultAsync(x => x.BurriedId == id);
        if (!string.IsNullOrEmpty(burriedDto.name))
            burried.Name = burriedDto.name;
        if (!string.IsNullOrEmpty(burriedDto.lastname))
            burried.Lastname = burriedDto.lastname;
        if (!string.IsNullOrEmpty(burriedDto.date_of_death.ToString()))
            burried.Date_of_death = burriedDto.date_of_death;
        if (!string.IsNullOrEmpty(burriedDto.date_of_birth.ToString()))
            burried.Date_of_birth = burriedDto.date_of_birth;
        await _contextModel.SaveChangesAsync();
        return burried;
    }
}