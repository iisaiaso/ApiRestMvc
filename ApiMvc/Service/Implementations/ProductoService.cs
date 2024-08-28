using ApiMvc.Models.Contracts;
using ApiMvc.Models.Entity;
using ApiMvc.Service.Cores.Exceptions;
using ApiMvc.Service.Dtos.Productos;
using AutoMapper;

namespace ApiMvc.Service.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductoService> _logger;

        public ProductoService(IProductoRepository productoRepository, IMapper mapper, ILogger<ProductoService> logger)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<ProductoSmallDto>> FindAllAsync()
        {
            // Obtener todos los productos desde el repositorio
            IReadOnlyList<Producto> productos = await _productoRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ProductoSmallDto>>(productos);
        }

        public async Task<ProductoDto> FindByIdAsync(int id)
        {
            // Obtener el producto desde el repositorio
            Producto? producto = await _productoRepository.FindByIdAsync(id);

            if (producto is null)
            {
               // _logger.LogWarning("Producnto no encontrado para el id:" + id);
                throw ProductoNotFound(id);
            }

            _logger.LogInformation("Producto {nombre}" + producto.Nombre);
            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task<ProductoDto> CreateAsync(ProductoSaveDto saveDto)
        {
            // Crear una nueva instancia de Producto y asignar propiedades desde saveDto
            Producto producto = _mapper.Map<Producto>(saveDto);

            // Guardar el producto utilizando el repositorio
            await _productoRepository.SaveAsync(producto);

            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task<ProductoSmallDto> EditAsync(int id, ProductoSaveDto saveDto)
        {
            // Buscar el producto existente por ID
            Producto? producto = await _productoRepository.FindByIdAsync(id);

            if (producto is null) throw ProductoNotFound(id);

            _mapper.Map<ProductoSaveDto, Producto>(saveDto, producto);

            // Guardar los cambios
            await _productoRepository.SaveAsync(producto);  

            return _mapper.Map<ProductoSmallDto>(producto);
        }

        public async Task<ProductoSmallDto> DisableAsync(int id)
        {
            // Obtener el producto eliminado del repositorio
            Producto? deletedProducto = await _productoRepository.DeleteAsync(id);

            if (deletedProducto is null) throw ProductoNotFound(id);

            return _mapper.Map<ProductoSmallDto>(deletedProducto);
        }

        private NotFoundCoreException ProductoNotFound(int id)
        {
            return new NotFoundCoreException("Producto no encontado para el id:" + id);
        }
    }
}
