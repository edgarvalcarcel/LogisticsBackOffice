using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Commands.AddWorkOrder;
public record AddWorkOrderCommand(
    int ProjectDetailId,
    int ServiceId,
    int OperatorId,
    decimal HoursAmount,
    DateTime? ScheduledStartDate,
    DateTime? ScheduledEndDate,
    DateTime? ModifiedEndDate,
    int ProjectId) : IRequest<WorkOrder>;


    

