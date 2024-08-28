using FluentValidation;

namespace ApiMvc.Service.Dtos.Fabricante.Validators
{
    public class FabricanteValidator : AbstractValidator<FabricanteSaveDto>
    {
        public FabricanteValidator() 
        {
            RuleFor(x => x.Nombre)
                .NotNull()
                .NotEmpty();
        }
    }
}
