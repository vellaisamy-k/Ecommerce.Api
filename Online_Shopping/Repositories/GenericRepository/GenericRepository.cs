using Ecommerce.Api.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Api.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EcommerceDbContext _dbContext;

        public GenericRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async void UpdateAsync(int id,T entity)
        {            

            //_dbContext.Entry(entity).State = EntityState.Modified;

            _dbContext.Set<T>().Update(entity);

             //_dbContext.Update(entity);
            await SaveChanges();
            
        }

        public bool IsRecordExists(Expression<Func<T, bool>> condition)
        {
            return _dbContext.Set<T>().AsQueryable().Where(condition).Any();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }


    }
}
