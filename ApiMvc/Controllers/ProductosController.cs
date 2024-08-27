using ApiMvc.Controllers.Exceptions;
using ApiMvc.Models;
using ApiMvc.Service;
using ApiMvc.Service.Dtos.Producto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/Productoes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoSmallDto))]
        public async Task<IEnumerable<ProductoSmallDto>> GetProducto()
        {
            return await _productoService.FindAllAsync();
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<ProductoDto>>> GetProducto(int id)
        {
            var response = await _productoService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoSmallDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<ProductoSmallDto>>> PutProducto(int id, [FromBody] ProductoSaveDto saveDto)
        {
            var response = await _productoService.EditAsync(id, saveDto);
            return TypedResults.Ok(response);
        }

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductoDto))]
        public async Task<ProductoDto> PostProducto([FromBody] ProductoSaveDto saveDto)
        {

            return await _productoService.CreateAsync(saveDto);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoSmallDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<ProductoSmallDto>>> DeleteProducto(int id)
        {
            var respose = await _productoService.DisableAsync(id);
            return TypedResults.Ok(respose);
        }


    }
}
