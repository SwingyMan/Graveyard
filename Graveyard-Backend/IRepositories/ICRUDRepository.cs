namespace Graveyard_Backend.IRepositories;

public interface ICRUDRepository<T>
{
	Task<T> add(T entity);
	Task<T> updateByID(int id, T entity);
	Task<bool> deleteByID(int id);
	Task<bool> deleteAll();
	Task<T> getByID(int id);
	Task<List<T>> ListAll(int page);
}