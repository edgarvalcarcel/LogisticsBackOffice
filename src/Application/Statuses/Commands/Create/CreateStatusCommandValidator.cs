using FluentValidation;
namespace LogisticsBackOffice.Application.Statuses.Commands.Create;
internal class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
{
    public CreateStatusCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Status name must not exceed 50 characters.");
    }
}