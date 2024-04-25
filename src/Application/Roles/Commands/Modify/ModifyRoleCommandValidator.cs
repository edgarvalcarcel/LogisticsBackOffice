
using FluentValidation;

namespace LogisticsBackOffice.Application.Roles.Commands.Modify;
public class ModifyRoleCommandValidator : AbstractValidator<ModifyRoleCommand>
{
    public ModifyRoleCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Role name must not exceed 50 characters.");
    }
}