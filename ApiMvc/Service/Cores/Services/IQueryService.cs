using ApiMvc.Models;

namespace ApiMvc.Service.Cores.Services
{
    public interface IQueryService<TDto,TSmallDto, ID>
    {
        Task<IReadOnlyList<TSmallDto>> FindAllAsync();
        Task<TDto> FindByIdAsync(ID id);
    }
}
