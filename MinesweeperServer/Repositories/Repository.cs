using Microsoft.EntityFrameworkCore;
using MinesweeperServer.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinesweeperServer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _dbContext;
        DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task CreateAsync(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity item)
        {
            _dbSet.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
