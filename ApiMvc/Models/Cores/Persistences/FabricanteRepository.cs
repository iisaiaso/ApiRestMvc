using ApiMvc.Models.Contracts;
using ApiMvc.Models.Cores.Context;
using ApiMvc.Models.Cores.Contracts.Persistences;
using ApiMvc.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiMvc.Models.Cores.Persistences
{
    public class FabricanteRepository : CrudRepository<Fabricante, int>, IFabricanteRepository
    {
        public FabricanteRepository(AppDataBaseContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Fabricante?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Fabricante>()
                .Include(f => f.Productos) // Incluye la colección de Productos, si es necesario
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
