using ApiMvc.Service.Cores.Services;
using ApiMvc.Service.Dtos.Fabricantes;

namespace ApiMvc.Service
{
    public interface IFabricanteService : ICrudService<FabricanteDto, FabricanteSaveDto, FabricanteSmallDto, int>
    {
    }
}
