using FluentValidation;
namespace LogisticsBackOffice.Application.Clients.Commands.Modify;
public class ModifyClientCommandValidator : AbstractValidator<ModifyClientCommand>
{
    public ModifyClientCommandValidator()
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

        RuleFor(c => c.AdditionalInfo).MaximumLength(100).WithMessage("Additional Info must not exceed 100 characters.");
        RuleFor(c => c.Title).MaximumLength(4).WithMessage("Title must not exceed 4 characters.");

        RuleFor(c => c.GeographicalInfo).NotNull().WithMessage("The Geographical Information is required");
        RuleFor(c => c.GeographicalInfo.AddressLine1).NotNull().NotEmpty().WithMessage("The Address line 1 must be provided")
            .MaximumLength(50).WithMessage("Address line 1 not exceed 50 characters");
        RuleFor(c => c.GeographicalInfo.AddressLine2).NotNull().NotEmpty().WithMessage("The Address line 2 must be provided").MaximumLength(50).WithMessage("The Address line 2 must be provided");
        RuleFor(c => c.GeographicalInfo.City).NotNull().NotEmpty().WithMessage("City name is required").MaximumLength(50).WithMessage("City not exceed 50 characters");
        RuleFor(c => c.GeographicalInfo.PostalCode).NotNull().NotEmpty().WithMessage("The Postal code must be provided").MaximumLength(10).WithMessage("Postal code not exceed 10 characters");
    }
}