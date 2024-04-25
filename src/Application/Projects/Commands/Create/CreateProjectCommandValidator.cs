using FluentValidation;
namespace LogisticsBackOffice.Application.Projects.Commands.Create;
public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(c => c.Client).NotNull().WithMessage("Client is required.").When(c => c.ClientId == null);
        RuleFor(c => c.ClientId).GreaterThan(0).NotNull().WithMessage("Client Id is required.").When(c => c.Client == null);
        RuleFor(c => c.Sidemark).NotEmpty().NotNull().WithMessage("Sidemark is required.");
        RuleFor(c => c.Contact).NotNull().WithMessage("The Contact Information is required");
        RuleFor(c => c.Amount).GreaterThan(0).NotNull().WithMessage("The Amount is required");
        RuleFor(c => c.CourierCompanyId).NotNull().WithMessage("The Delivery Company Id must be provided");
        RuleFor(c => c.InspectionNotes)
            .NotEmpty().WithMessage("Inspection Notes is required.")
            .MaximumLength(50).WithMessage("Inspection must not exceed 50 characters.");

        RuleFor(c => c.EmailSent).NotNull()
            .NotEmpty().WithMessage("EmailSent is required.")
            .MaximumLength(50).WithMessage("Email Sent not exceed 100 characters.")
            .When(c => c.ReplaytoEmail == true)
        .WithMessage("Email Sent is required when Replay to email is true.");

        RuleFor(c => c.DriverName).NotEmpty().WithMessage("DriverName is required.").MaximumLength(50).WithMessage("DriverName not exceed 100 characters.");
        RuleFor(c => c.ShippingNumber).NotEmpty().WithMessage("ShippingNumber is required.").MaximumLength(50).WithMessage("Shipping Number not exceed 100 characters.");
        RuleFor(c => c.ShipperOrigin).NotEmpty().WithMessage("Shipper Origin is required.").MaximumLength(50).WithMessage("DriverName not exceed 100 characters.");
        RuleFor(c => c.ProjectDetail).NotNull().WithMessage("The Project Detail Information is required");

    }
}