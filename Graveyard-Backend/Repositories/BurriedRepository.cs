using System.Runtime.InteropServices.JavaScript;
using Graveyard_Backend.DTOs;
using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Burried = Graveyard_Backend.DTOs.Burried;

namespace Graveyard_Backend.Repositories;

public class BurriedRepository : CRUDRepository<Models.Burried>,IBurriedRepository
{
    private readonly contextModel _contextModel;

    public BurriedRepository(contextModel contextModel)
    {
        _contextModel = contextModel;
    }
    public async Task<Models.Burried> UpdateById(int id, Burried burriedDto)
    {
        var burried = await _contextModel.burried.FirstOrDefaultAsync(x => x.BurriedId == id);
        if (!String.IsNullOrEmpty(burriedDto.name))
            burried.name = burriedDto.name;
        if (!String.IsNullOrEmpty(burriedDto.lastname))
            burried.lastname = burriedDto.lastname;
        if (!String.IsNullOrEmpty(burriedDto.date_of_death.ToString()))
            burried.date_of_death = burriedDto.date_of_death;
        if(!String.IsNullOrEmpty(burriedDto.date_of_birth.ToString()))
            burried.date_of_birth = burriedDto.date_of_birth;
        await _contextModel.SaveChangesAsync();
        return burried;
    }
}