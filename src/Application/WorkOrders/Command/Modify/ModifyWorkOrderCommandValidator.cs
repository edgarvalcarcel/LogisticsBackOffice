using FluentValidation;
namespace LogisticsBackOffice.Application.WorkOrders.Command.Modify;
public class ModifyWorkOrderCommandValidator : AbstractValidator<ModifyWorkOrderCommand>
{
    public ModifyWorkOrderCommandValidator()
    {
        RuleFor(c => c.Id).GreaterThan(0).NotNull().WithMessage("Id is required.");
        RuleFor(c => c.ProjectId).GreaterThan(0).NotNull().WithMessage("Project Id is required.");
        RuleFor(c => c.ProjectDetailId).GreaterThan(0).NotNull().WithMessage("Project Detail Id is required.");
        RuleFor(c => c.ProjectId).GreaterThan(0).NotNull().WithMessage("Project Id is required.");
        RuleFor(c => c.ServiceId).GreaterThan(0).NotNull().WithMessage("Service Id is required.");
        RuleFor(c => c.HoursAmount).GreaterThan(0).NotNull().WithMessage("The hours Amount is required and greater than 0");

        RuleFor(p => p.ScheduledStartDate)
            .NotEmpty().WithMessage("The Start date is required")
            .Must(date => date != default(DateTime)).WithMessage("Must be a Validate date");

        RuleFor(p => p.ScheduledEndDate)
            .NotEmpty().WithMessage("The End date is required")
            .GreaterThanOrEqualTo(p => p.ScheduledStartDate).WithMessage("The End date must be equal or greater than Start date")
            .Must(date => date != default(DateTime)).WithMessage("Must be a Validate date");

        RuleFor(c => c.StaffId).GreaterThan(0).NotNull()
            .When(c => c.ReportToStaff == true)
            .WithMessage("Staff Id is required when Report staff is true.");
        RuleFor(c => c.WorkOrderDetail).NotNull().WithMessage("The WorkOrder Detail Id is required.");
    }
}
