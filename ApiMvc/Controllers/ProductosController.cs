using ApiMvc.Models;
using ApiMvc.Service;
using ApiMvc.Service.Dtos.Producto;
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
        public async Task<IEnumerable<ProductoSmallDto>> GetProducto()
        {
            return await _productoService.FindAllAsync();
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ProductoDto?> GetProducto(int id)
        {
          return await _productoService.FindByIdAsync(id);
        }

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ProductoSmallDto?> PutProducto(int id, [FromBody] ProductoSaveDto saveDto)
        {
            return await _productoService.EditAsync(id, saveDto);
        }

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ProductoDto> PostProducto([FromBody] ProductoSaveDto saveDto)
        {
          return await _productoService.CreateAsync(saveDto);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<ProductoSmallDto?> DeleteProducto(int id)
        {
            return await _productoService.DisableAsync(id);
        }

        
    }
}
