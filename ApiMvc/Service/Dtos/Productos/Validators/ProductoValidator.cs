using FluentValidation;

namespace ApiMvc.Service.Dtos.Productos.Validators
{
    public class ProductoValidator : AbstractValidator<ProductoSaveDto>
    {
        public ProductoValidator() 
        {
            RuleFor(x => x.Nombre)
                .NotNull()
                .Length(1, 15).WithMessage("Name should be between 1 and 100 chars");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
