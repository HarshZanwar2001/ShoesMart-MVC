namespace eCommerceApplication.Repository;

public interface ICommonRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetDetailsAsync(int id);
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
}
