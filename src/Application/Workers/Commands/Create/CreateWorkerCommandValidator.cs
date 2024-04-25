using FluentValidation;
 
namespace LogisticsBackOffice.Application.Workers.Commands.Create;
public class CreateWorkerCommandValidator : AbstractValidator<CreateWorkerCommand>
{
    public CreateWorkerCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("FirstName is required.")
            .MaximumLength(50).WithMessage("Firstname must not exceed 50 characters.");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("LastName is required.")
            .MaximumLength(50).WithMessage("LastName must not exceed 50 characters.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

        RuleFor(c => c.Role)
          .NotEmpty().WithMessage("Role is required.")
          .MaximumLength(100).WithMessage("Role must not exceed 100 characters.");

        RuleFor(c => c.Title).MaximumLength(4).WithMessage("Title must not exceed 4 characters.");
        RuleFor(c => c.AdditionalInfo).MaximumLength(100).WithMessage("Additional Info must not exceed 100 characters.");

        RuleFor(c => c.GeographicalInfo).NotNull().WithMessage("The Geographical Information is required");
        RuleFor(c => c.GeographicalInfo.AddressLine1).NotEmpty().WithMessage("The Address line 1 must be provided")
            .MaximumLength(50).WithMessage("Address line 1 not exceed 50 characters");
        RuleFor(c => c.GeographicalInfo.AddressLine2).NotEmpty().WithMessage("The Address line 2 must be provided").MaximumLength(50).WithMessage("The Address line 2 must be provided");
        RuleFor(c => c.GeographicalInfo.City).NotEmpty().WithMessage("City name is required").MaximumLength(50).WithMessage("City not exceed 50 characters");
        RuleFor(c => c.GeographicalInfo.PostalCode).NotEmpty().WithMessage("The Postal code must be provided").MaximumLength(10).WithMessage("Postal code not exceed 10 characters");
        RuleFor(c => c.GeographicalInfo.StateId).NotNull().WithMessage("The State Id must be provided");
        RuleFor(c => c.GeographicalInfo.PhoneNumber).NotEmpty().WithMessage("Phone number is required").NotNull().WithMessage("The State Id must be provided");
    }
}