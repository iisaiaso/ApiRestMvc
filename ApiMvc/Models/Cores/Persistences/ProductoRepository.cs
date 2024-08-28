using ApiMvc.Models.Contracts;
using ApiMvc.Models.Cores.Context;
using ApiMvc.Models.Cores.Contracts.Persistences;
using ApiMvc.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiMvc.Models.Cores.Persistences
{
    public class ProductoRepository : CrudRepository<Producto, int>, IProductoRepository
    {

        public ProductoRepository(AppDataBaseContext dbContext) : base(dbContext)
        {

        }
        //public ProductoRepository(AppDataBaseContext context)
        //{
        //    _context = context;
        //}

        public override async Task<IReadOnlyList<Producto>> FindAllAsync()
        {
            return await  _dbContext.Set<Producto>()
                .Include(p => p.Fabricante)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Producto?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Producto>()
                .Include(p => p.Fabricante)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<Producto> SaveAsync(Producto entity)
        {
            EntityState state = _dbContext.Entry(entity).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.Set<Producto>().Add(entity),
                EntityState.Modified => _dbContext.Set<Producto>().Update(entity),
                _ => throw new ArgumentOutOfRangeException()
            };
            await _dbContext.SaveChangesAsync();
            return await FindByIdAsync(entity.Id) ?? entity;
        }

        //public async Task<Producto> DeleteAsync(int id)
        //{
        //     var producto = await _context.Producto.FindAsync(id);

        //    if (producto == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Producto.Remove(producto);
        //   await _context.SaveChangesAsync();
        //    return producto;
        //}

        //private Producto NotFound()
        //{
        //    throw new NotImplementedException("Not Found");
        //}

    }
}
