using ApiMvc.Models;
using ApiMvc.Models.Contracts;
using ApiMvc.Models.Entity;
using ApiMvc.Service.Cores.Exceptions;
using ApiMvc.Service.Dtos.Fabricante;
using ApiMvc.Service.Dtos.Producto;

namespace ApiMvc.Service.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IReadOnlyList<ProductoSmallDto>> FindAllAsync()
        {
            // Obtener todos los productos desde el repositorio
            var productos = await _productoRepository.FindAllAsync();

            // Convertir productos a ProductoSmallDto
            var productoSmallDto = productos.Select(p => new ProductoSmallDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                // Agrega aquí las propiedades que necesites mapear
            }).ToList(); // Convertir a List para que coincida con IReadOnlyList

            return productoSmallDto;
        }

        public async Task<ProductoDto> FindByIdAsync(int id)
        {
            // Obtener el producto desde el repositorio
            Producto? producto = await _productoRepository.FindByIdAsync(id);

            if (producto is null) throw ProductoNotFound(id);

            // Mapear Producto a ProductoDto
            ProductoDto productoDto = new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                FabricanteId = producto.FabricanteId,
                Fabricante = producto.Fabricante == null ? null : new FabricanteSmallDto
                {
                    Id = producto.Fabricante.Id,
                    Nombre = producto.Fabricante.Nombre
                    // Mapear más propiedades si es necesario
                }
                // Mapea aquí todas las propiedades necesarias para ProductoDto
            };

            return productoDto;
        }

        public async Task<ProductoDto> CreateAsync(ProductoSaveDto saveDto)
        {
            // Crear una nueva instancia de Producto y asignar propiedades desde saveDto
            Producto producto = new Producto
            {
                Nombre = saveDto.Nombre,
                Precio = saveDto.Precio,
                FabricanteId = saveDto.FabricanteId
                // Asigna aquí todas las demás propiedades que necesites
            };

            // Guardar el producto utilizando el repositorio
            Producto savedProducto = await _productoRepository.SaveAsync(producto);

            Producto? findProduct = await _productoRepository.FindByIdAsync(savedProducto.Id);

            if (findProduct is null) throw ProductoNotFound(savedProducto.Id);

            // Mapear Producto a ProductoDto manualmente
            ProductoDto productoDto = new ProductoDto
            {
                Id = findProduct.Id,
                Nombre = findProduct.Nombre,
                Precio = findProduct.Precio,
                FabricanteId = findProduct.FabricanteId,
                Fabricante = findProduct.Fabricante == null ? null : new FabricanteSmallDto
                {
                    Id = findProduct.Fabricante.Id,
                    Nombre = findProduct.Fabricante.Nombre
                }
                // Asigna aquí todas las demás propiedades que necesites mapear
            };

            return productoDto;
        }

        public async Task<ProductoSmallDto> EditAsync(int id, ProductoSaveDto saveDto)
        {
            // Buscar el producto existente por ID
            Producto? producto = await _productoRepository.FindByIdAsync(id);

            if (producto is null) throw ProductoNotFound(id);

            // Actualizar las propiedades del producto con los datos de saveDto
            producto.Nombre = saveDto.Nombre;
            producto.Precio = saveDto.Precio;
            producto.FabricanteId = saveDto.FabricanteId;
            // Agrega aquí todas las propiedades que necesites actualizar

            // Guardar los cambios
            await _productoRepository.SaveAsync(producto);  // Asume que tienes un método UpdateAsync en el repositorio

            // Mapear Producto a ProductoSmallDto manualmente
            ProductoSmallDto productoSmallDto = new ProductoSmallDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                // Mapea aquí todas las propiedades necesarias para ProductoSmallDto
            };

            return productoSmallDto;
        }

        public async Task<ProductoSmallDto> DisableAsync(int id)
        {
            // Obtener el producto eliminado del repositorio
            Producto? deletedProducto = await _productoRepository.DeleteAsync(id);

            if (deletedProducto is null) throw ProductoNotFound(id);

            // Mapear Producto a ProductoSmallDto manualmente
            ProductoSmallDto productoSmallDto = new ProductoSmallDto
            {
                Id = deletedProducto.Id,
                Nombre = deletedProducto.Nombre,
                // Mapea aquí todas las propiedades necesarias para ProductoSmallDto
            };

            return productoSmallDto;
        }

        private NotFoundCoreException ProductoNotFound(int id)
        {
            return new NotFoundCoreException("Producto no encontado para el id:" + id);
        }
    }
}
