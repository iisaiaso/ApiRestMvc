using ApiMvc.Models;
using ApiMvc.Models.Contracts;
using ApiMvc.Models.Entity;
using ApiMvc.Service.Dtos.Fabricante;

namespace ApiMvc.Service.Implementations
{
    public class FabricanteService : IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public FabricanteService(IFabricanteRepository fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }

        public async Task<IReadOnlyList<FabricanteSmallDto>> FindAllAsync()
        {
            var fabricante = await _fabricanteRepository.FindAllAsync();

            var smallDto = fabricante.Select(x => new FabricanteSmallDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
            }).ToList();

            return smallDto;
        }

        public async Task<FabricanteDto?> FindByIdAsync(int id)
        {
            Fabricante? fabricante = await _fabricanteRepository.FindByIdAsync(id);

            if (fabricante != null) 
            {
                FabricanteDto fabricanteDto = new FabricanteDto
                {
                    Id = fabricante.Id,
                    Nombre = fabricante.Nombre,
                    Productos = fabricante.Productos?.Select(producto => new ProductoSmallDto
                    {
                        Id = producto.Id,
                        Nombre = producto.Nombre
                    }).ToList() ?? new List<ProductoSmallDto>()
                };
                return fabricanteDto;
            }
                FabricanteNotFound(id);
                return null;
        }
        private Exception FabricanteNotFound(int id)
        {
            throw new InvalidOperationException("Fabricante no encontado para el id:" + id);
        }
    }
}
