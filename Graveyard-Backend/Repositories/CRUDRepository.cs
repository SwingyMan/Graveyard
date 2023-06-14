using Graveyard_Backend.IRepositories;
using Graveyard_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Graveyard_Backend.Repositories;

public class CRUDRepository<T> : ICRUDRepository<T> where T : class
{
    private readonly ContextModel _contextModel;
    private readonly DbSet<T> table;

    public CRUDRepository()
    {
        _contextModel = new ContextModel();
        table = _contextModel.Set<T>();
    }

    public CRUDRepository(ContextModel context)
    {
        _contextModel = context;
        table = _contextModel.Set<T>();
    }

    public async Task<T> add(T entity)
    {
        await table.AddAsync(entity);
        await _contextModel.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> deleteAll()
    {
        var list = table.ToList();
        foreach (var entity in list) table.Remove(entity);
        await _contextModel.SaveChangesAsync();
        return true;
    }

    public async Task<bool> deleteByID(int id)
    {
        var x = await table.FindAsync(id);
        if (x == null)
            return false;
        table.Remove(x);
        await _contextModel.SaveChangesAsync();
        return true;
    }

    public async Task<T> getByID(int id)
    {
        var entity = await table.FindAsync(id);
        return entity;
    }

    public async Task<List<T>> ListAll(int page)
    {
        return await table.Skip(page * 10).Take(10).ToListAsync();
    }

    public async Task<T> updateByID(int id, T entity)
    {
        var entity1 = await table.FindAsync(id);
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
            if (property.GetValue(entity, null) != null)
                property.SetValue(entity, entity1, null);
        await _contextModel.SaveChangesAsync();
        return entity1;
    }

    public List<T> List()
    {
        return table.ToList();
    }
}