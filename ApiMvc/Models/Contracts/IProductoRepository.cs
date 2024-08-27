using ApiMvc.Models.Cores.Contracts;
using ApiMvc.Models.Entity;

namespace ApiMvc.Models.Contracts
{
    public interface IProductoRepository:ICrudRepository<Producto, int>
    {
        //Task<IReadOnlyList<Producto>> FindAllAsync();
        //Task<Producto> FindByIdAsync(int id);
        //Task<Producto> SaveAsync(Producto producto);
        //Task<Producto> DeleteAsync(int id);
    }
}
