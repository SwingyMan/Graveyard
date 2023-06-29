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

    public async Task<Burried> UpdateById(int id, Burried burriedDto)
    {
        var burried = await _contextModel.Burried.FirstOrDefaultAsync(x => x.BurriedId == id);
        if (!string.IsNullOrEmpty(burriedDto.Name))
            burried.Name = burriedDto.Name;
        if (!string.IsNullOrEmpty(burriedDto.Lastname))
            burried.Lastname = burriedDto.Lastname;
        if (!string.IsNullOrEmpty(burriedDto.Date_of_death.ToString()))
            burried.Date_of_death = burriedDto.Date_of_death;
        if (!string.IsNullOrEmpty(burriedDto.Date_of_birth.ToString()))
            burried.Date_of_birth = burriedDto.Date_of_birth;
        await _contextModel.SaveChangesAsync();
        return burried;
    }

    public async Task<List<Burried>> GetToBeBurried()
    {
        return await _contextModel.Burried.Where(x=>DateTime.Compare(x.BurialDate,DateTime.Now) > 0).ToListAsync();
    }
}