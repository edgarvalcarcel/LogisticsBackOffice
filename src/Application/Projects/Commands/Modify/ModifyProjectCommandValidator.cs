using FluentValidation;
namespace LogisticsBackOffice.Application.Projects.Commands.Modify;
public class ModifyProjectCommandValidator : AbstractValidator<ModifyProjectCommand>
{
    public ModifyProjectCommandValidator()
    {
        RuleFor(c => c.Id).GreaterThan(0).NotNull().WithMessage("Id is required.");
        RuleFor(c => c.ClientId).GreaterThan(0).NotNull().WithMessage("Client Id is required.");
        RuleFor(c => c.Sidemark).NotNull().WithMessage("Sidemark is required.");
        RuleFor(c => c.Contact).NotNull().WithMessage("The Contact Information is required");
        RuleFor(c => c.Amount).GreaterThan(0).NotNull().WithMessage("The Amount is required");
        RuleFor(c => c.CourierCompanyId).NotNull().WithMessage("The Delivery Company Id must be provided");
        RuleFor(c => c.InspectionNotes)
            .NotEmpty().WithMessage("Inspection Notes is required.")
            .MaximumLength(50).WithMessage("InspectionNotes must not exceed 50 characters.");
        //RuleFor(c => c.ReceivingWorkerId).NotNull().WithMessage("The Delivery Company Id must be provided");
        RuleFor(c => c.DriverName).NotEmpty().WithMessage("DriverName is required.").MaximumLength(50).WithMessage("DriverName not exceed 100 characters.");
        RuleFor(c => c.ShippingNumber).NotEmpty().WithMessage("ShippingNumber is required.").MaximumLength(50).WithMessage("Shipping Number not exceed 100 characters.");
        RuleFor(c => c.ShipperOrigin).NotEmpty().WithMessage("Shipper Origin is required.").MaximumLength(50).WithMessage("DriverName not exceed 100 characters.");
        RuleFor(c => c.ProjectDetail).NotNull().WithMessage("The Project Detail Information is required");
    }
}