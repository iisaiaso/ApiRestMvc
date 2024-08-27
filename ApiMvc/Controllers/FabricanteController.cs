using ApiMvc.Service;
using ApiMvc.Service.Dtos.Fabricante;
using Microsoft.AspNetCore.Mvc;

namespace ApiMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly IFabricanteService _fabricanteService;

        public FabricanteController(IFabricanteService fabricanteService)
        {
            _fabricanteService = fabricanteService;
        }

        // GET: api/FabricanteDtoes
        [HttpGet]
        public async Task<IEnumerable<FabricanteSmallDto>> GetFabricanteDto()
        {
          return await _fabricanteService.FindAllAsync();
        }

        // GET: api/FabricanteDtoes/5
        [HttpGet("{id}")]
        public async Task<FabricanteDto?> GetFabricanteDto(int id)
        {
            return await _fabricanteService.FindByIdAsync(id);
        }
    }
}
