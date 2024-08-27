using ApiMvc.Models.Cores.Contracts;
using ApiMvc.Models.Entity;

namespace ApiMvc.Models.Contracts
{
    public interface IFabricanteRepository : ICrudRepository<Fabricante, int>
    {
    }
}
