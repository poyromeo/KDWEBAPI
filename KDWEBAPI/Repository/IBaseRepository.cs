using System.Security.Principal;

namespace KDWEBAPI.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
