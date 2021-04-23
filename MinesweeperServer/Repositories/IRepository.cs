using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinesweeperServer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(object id);
        Task<List<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity item);
        Task DeleteAsync(TEntity item);
        Task UpdateAsync(TEntity item);
    }
}
