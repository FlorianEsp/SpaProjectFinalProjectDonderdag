using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaProjectFinalProject.GenericRepo
{
    public class Repo<TDbContext> : IRepo where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        public Repo(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> SelectAsync<T>() where T : class
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> SelectById<T>(int id) where T : class
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
