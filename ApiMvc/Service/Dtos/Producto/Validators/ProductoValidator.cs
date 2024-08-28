
using FluentValidation;

namespace ApiMvc.Service.Dtos.Producto.Validators
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
