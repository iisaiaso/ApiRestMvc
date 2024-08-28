using ApiMvc.Models.Entity;
using AutoMapper;

namespace ApiMvc.Service.Dtos.Productos.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile() 
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<Producto, ProductoSmallDto>();

            CreateMap<Producto, ProductoSaveDto>().ReverseMap();
        }
    }
}
