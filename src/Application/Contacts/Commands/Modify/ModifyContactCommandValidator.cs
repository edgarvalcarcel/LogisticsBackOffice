using FluentValidation;
using LogisticsBackOffice.Application.Contacts.Commands.Modify;

namespace LogisticsBackOffice.Application.Workers.Command.Modify;
public class ModifyContactCommandValidator : AbstractValidator<ModifyContactCommand>
{
    public ModifyContactCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("FirstName is required.")
            .MaximumLength(50).WithMessage("FirstName must not exceed 50 characters.");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("LastName is required.")
            .MaximumLength(50).WithMessage("LastName must not exceed 50 characters.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

        RuleFor(c => c.Role)
          .NotEmpty().WithMessage("Role is required.")
          .MaximumLength(50).WithMessage("Role must not exceed 50 characters.");

        RuleFor(c => c.Title).NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(c => c.AdditionalInfo).MaximumLength(100).WithMessage("Additional Info must not exceed 100 characters.");

        RuleFor(c => c.Cellphone).MaximumLength(100).WithMessage("Cellphone must not exceed 100 characters.");
    }
}