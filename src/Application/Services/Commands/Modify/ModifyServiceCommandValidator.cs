using FluentValidation;
namespace LogisticsBackOffice.Application.Services.Commands.Modify;
public class ModifyServiceCommandValidator : AbstractValidator<ModifyServiceCommand>
{
    public ModifyServiceCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("service name must not exceed 50 characters.");
        RuleFor(c => c.Rate).GreaterThan(0).NotNull().WithMessage("The Rate is required");
    }
}