using FluentValidation;

namespace ApiMvc.Service.Dtos.Fabricantes.Validators
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
