using ApiMvc.Models;

namespace ApiMvc.Service.Cores.Services
{
    public interface IDisableService<TSmallDto, ID>
    {
        Task<TSmallDto?> DisableAsync(ID id);

    }
}
