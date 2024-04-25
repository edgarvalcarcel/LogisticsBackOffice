using FluentValidation;

namespace LogisticsBackOffice.Application.Statuses.Commands.Modify;
public class ModifyStatusCommandValidator : AbstractValidator<ModifyStatusCommand>
{
    public ModifyStatusCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Status name must not exceed 50 characters.");
    }
}