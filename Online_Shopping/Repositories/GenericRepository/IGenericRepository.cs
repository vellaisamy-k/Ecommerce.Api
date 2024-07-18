using System.Linq.Expressions;

namespace Ecommerce.Api.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        void UpdateAsync(int id, T entity);
        Task SaveChanges();

        bool IsRecordExists(Expression<Func<T, bool>> exception);

    }
}
