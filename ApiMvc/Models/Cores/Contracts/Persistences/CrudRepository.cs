using ApiMvc.Models.Cores.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiMvc.Models.Cores.Contracts.Persistences
{
    public abstract class CrudRepository<T, ID> : ICrudRepository<T, ID> where T : class
    {
        public readonly AppDataBaseContext _dbContext;

        protected CrudRepository(AppDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<IReadOnlyList<T>> FindAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }
        public virtual async Task<T?> FindByIdAsync(ID id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public virtual async Task<T> SaveAsync(T entity)
        {
            EntityState state = _dbContext.Entry(entity).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.Set<T>().Add(entity),
                EntityState.Modified => _dbContext.Set<T>().Update(entity),
                _ => throw new ArgumentOutOfRangeException() // Cláusula default para cualquier otro caso no manejado
            };
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<T?> DeleteAsync(ID id)
        {
            T? entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return default;
            }
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
