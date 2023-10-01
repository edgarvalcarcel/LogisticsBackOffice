using LogisticsBackOffice.Domain.Entities;
using HotChocolate;
using HotChocolate.Types.Relay;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Commands.ModifyWorkOrder;
public record ModifyWorkOrderCommand(
    [property: ID(nameof(WorkOrder))] int Id,
    Optional<int> ProjectDetailId,
    Optional<int> ServiceId,
    Optional<int> OperatorId,
    Optional<decimal> HoursAmount,
    Optional<DateTime?> ScheduledStartDate,
    Optional<DateTime?> ScheduledEndDate,
    Optional<DateTime?> ModifiedEndDate,
    Optional<int> ProjectId 
    ) : IRequest<WorkOrder?>;
