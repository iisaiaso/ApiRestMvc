
using ApiMvc.Models;
using ApiMvc.Service.Cores.Services;
using ApiMvc.Service.Dtos.Producto;

namespace ApiMvc.Service
{
    public interface IProductoService:ICrudService<ProductoDto, ProductoSaveDto, ProductoSmallDto, int>
    {
        //Task<IReadOnlyList<ProductoSmallDto>> FindAllAsync();
        //Task<ProductoDto> FindByIdAsync(int id);
        //Task<ProductoDto> CreateAsync(ProductoSaveDto saveDto);
        //Task<ProductoSmallDto> EditAsync(int id, ProductoSaveDto saveDto);
        //Task<ProductoSmallDto> DisableAsync(int id);
    }
}
