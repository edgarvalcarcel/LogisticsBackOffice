using FluentValidation;
namespace LogisticsBackOffice.Application.Roles.Commands.Create;
public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Role name must not exceed 50 characters.");
    }
}