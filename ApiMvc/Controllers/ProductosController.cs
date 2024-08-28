﻿using ApiMvc.Controllers.Exceptions;
using ApiMvc.Models;
using ApiMvc.Service;
using ApiMvc.Service.Dtos.Producto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Comentar esto para desabilite validación automática
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
        public async Task<IEnumerable<ProductoSmallDto>> Get()
        {
            return await _productoService.FindAllAsync();
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<ProductoDto>>> Get(int id)
        {
            var response = await _productoService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoSmallDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<ProductoSmallDto>>> Put(int id, [FromBody] ProductoSaveDto saveDto)
        {
            var response = await _productoService.EditAsync(id, saveDto);
            return TypedResults.Ok(response);
        }

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductoDto))]
        public async Task<IResult> Post([FromBody] ProductoSaveDto saveDto)
        {
            if (!ModelState.IsValid)
            {
                var rs = ModelState.Where(x => x.Value?.Errors.Count() > 0).ToArray();
                return Results.BadRequest(rs);
            }
            var respose = await _productoService.CreateAsync(saveDto);
            return Results.Ok(respose);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoSmallDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<ProductoSmallDto>>> Delete(int id)
        {
            var respose = await _productoService.DisableAsync(id);
            return TypedResults.Ok(respose);
        }


    }
}
