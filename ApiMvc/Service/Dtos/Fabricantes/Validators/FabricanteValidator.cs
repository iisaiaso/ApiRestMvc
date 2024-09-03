using FluentValidation;

namespace ApiMvc.Service.Dtos.Fabricantes.Validators
{
    public class FabricanteValidator : AbstractValidator<FabricanteSaveDto>
    {
        public FabricanteValidator() 
        {
            RuleFor(x => x.Nombre)
                .NotNull()
                .Length(1, 15).WithMessage("Name should be between 1 and 15 chars");
        }
    }
}
