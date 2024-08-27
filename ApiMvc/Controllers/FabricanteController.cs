using ApiMvc.Controllers.Exceptions;
using ApiMvc.Service;
using ApiMvc.Service.Dtos.Fabricante;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FabricanteSmallDto))]
        public async Task<IEnumerable<FabricanteSmallDto>> GetFabricante()
        {
            return await _fabricanteService.FindAllAsync();
        }

        // GET: api/FabricanteDtoes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FabricanteDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound,Ok<FabricanteDto>>> GetFabricante(int id)
        {
            var response = await _fabricanteService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
