using ApiMvc.Models.Contracts;
using ApiMvc.Models.Entity;
using ApiMvc.Service.Cores.Exceptions;
using ApiMvc.Service.Dtos.Fabricantes;
using ApiMvc.Service.Dtos.Productos;
using AutoMapper;

namespace ApiMvc.Service.Implementations
{
    public class FabricanteService : IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FabricanteService> _logger;

        public FabricanteService(IFabricanteRepository fabricanteRepository, IMapper mapper, ILogger<FabricanteService> logger)
        {
            _fabricanteRepository = fabricanteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<FabricanteSmallDto>> FindAllAsync()
        {
            IReadOnlyList<Fabricante> fabricante = await _fabricanteRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<FabricanteSmallDto>>(fabricante);
        }

        public async Task<FabricanteDto> FindByIdAsync(int id)
        {
            Fabricante? fabricante = await _fabricanteRepository.FindByIdAsync(id);

            if (fabricante is null)
            {
               // _logger.LogWarning("Fabricante no encontrado para el id:" + id);
                throw FabricanteNotFound(id);
            }

            _logger.LogInformation("Fabricante {nombre}"+fabricante.Nombre);
            return _mapper.Map<FabricanteDto>(fabricante);

        }

        private NotFoundCoreException FabricanteNotFound(int id)
        {
            return new NotFoundCoreException("Fabricante no encontado para el id:" + id);
        }
    }
}
