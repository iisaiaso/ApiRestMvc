using ApiMvc.Service.Dtos.Productos;
using FluentValidation;

namespace ApiMvc.Service.Dtos.Productos.Validators
{
    public class ProductoValidator : AbstractValidator<ProductoSaveDto>
    {
        public ProductoValidator() 
        {
            RuleFor(x => x.Nombre)
                .NotNull()
                .NotEmpty();
        }
    }
}
