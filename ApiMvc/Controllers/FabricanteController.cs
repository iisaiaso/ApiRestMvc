using ApiMvc.Controllers.Exceptions;
using ApiMvc.Service;
using ApiMvc.Service.Dtos.Fabricantes;
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

        // GET: api/Fabricante
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FabricanteSmallDto))]
        public async Task<IEnumerable<FabricanteSmallDto>> Get()
        {
            return await _fabricanteService.FindAllAsync();
        }

        // GET: api/Fabricante/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FabricanteDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound,Ok<FabricanteDto>>> Get(int id)
        {
            var response = await _fabricanteService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // Post: api/Fabricante
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(FabricanteDto))]
        public async Task<FabricanteDto> Post([FromBody] FabricanteSaveDto saveDto) 
        {
            return await _fabricanteService.CreateAsync(saveDto);
        }

        // Put: api/Fabricante/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FabricanteSmallDto))]
        public async Task<Results<NotFound, Ok<FabricanteSmallDto>>> Put(int id, [FromBody] FabricanteSaveDto saveDto) 
        {
            var response = await _fabricanteService.EditAsync(id, saveDto);
            return TypedResults.Ok(response);
        }

        // Delete: api/Fabricante/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<FabricanteSmallDto>>> Delete(int id) 
        {
            var response = await _fabricanteService.DisableAsync(id);
            return TypedResults.Ok(response);
        }

    }
}
