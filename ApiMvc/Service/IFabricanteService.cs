using ApiMvc.Service.Cores.Services;
using ApiMvc.Service.Dtos.Fabricante;

namespace ApiMvc.Service
{
    public interface IFabricanteService : IQueryService<FabricanteDto, FabricanteSmallDto, int>
    {
    }
}
