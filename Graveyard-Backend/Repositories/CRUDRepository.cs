using Graveyard.Models;
using Graveyard_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Graveyard_Backend.Repositories
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        private contextModel _contextModel = null;
        private DbSet<T> table = null;
        public CRUDRepository() { _contextModel = new contextModel();
            table = _contextModel.Set<T>(); }
        public CRUDRepository(contextModel context)
        {
            _contextModel = context;
            table = _contextModel.Set<T>();
        }
        public async Task<T> add(T entity)
        {
            table.Add(entity);
            await _contextModel.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> deleteAll()
        {
            var list = table.ToList();
              foreach (var entity in list) { 
                table.Remove(entity);
            }
           await _contextModel.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteByID(int id)
        {
            var x = await table.FindAsync(id);
            if(x==null)
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
            return await table.Skip(page*10).Take(10).ToListAsync();
        }
        public List<T> List()
        { return table.ToList(); }

        public async Task<T> updateByID(int id, T entity)
        {
            var entity1 =await table.FindAsync(id);
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(entity, null) != null)
                    property.SetValue(entity, entity1, null);
            }
            await _contextModel.SaveChangesAsync();
            return entity1;
        }
    }
}
