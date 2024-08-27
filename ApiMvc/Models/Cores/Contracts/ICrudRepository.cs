using ApiMvc.Models.Entity;
using System.Linq.Expressions;

namespace ApiMvc.Models.Cores.Contracts
{
    public interface ICrudRepository<T,ID>
    {
        Task<IReadOnlyList<T>> FindAllAsync();
        Task<T?> FindByIdAsync(ID id);
        Task<T> SaveAsync(T entity);
        Task<T?> DeleteAsync(ID id);
    }
}
