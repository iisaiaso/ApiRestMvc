
using ApiMvc.Models.Entity;
using AutoMapper;

namespace ApiMvc.Service.Dtos.Fabricantes.Profiles
{
    public class FabricanteProfile : Profile
    {
        public FabricanteProfile()
        {
            CreateMap<Fabricante, FabricanteDto>();
            CreateMap<Fabricante, FabricanteSmallDto>();

            CreateMap<Fabricante, FabricanteSaveDto>().ReverseMap();
        }
    }
}
