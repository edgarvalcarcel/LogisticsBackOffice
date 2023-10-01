using HotChocolate;
using LogisticsBackOffice.Application.Clients.Commands.ModifyClient;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Commands.ModifyWorkOrder;

public class ModifyWorkOrderCommandHandler : IRequestHandler<ModifyWorkOrderCommand, WorkOrder?>
{
    private readonly IWorkOrderRepository _repository;

    public ModifyWorkOrderCommandHandler(IWorkOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<WorkOrder?> Handle(ModifyWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var workOrder = await _repository.FindWorkOrderByIdAsync(request.Id, cancellationToken);

        if (workOrder is null) return workOrder;
 
        if (request.ProjectDetailId.HasValue) workOrder.ProjectDetailId = request.ProjectDetailId;
        if (request.ServiceId.HasValue) workOrder.ServiceId = request.ServiceId;
        if (request.OperatorId.HasValue) workOrder.OperatorId = request.OperatorId;
        if (request.HoursAmount.HasValue) workOrder.HoursAmount = request.HoursAmount;
        if (request.ScheduledStartDate.HasValue) workOrder.ScheduledStartDate = request.ScheduledStartDate;
        if (request.ScheduledEndDate.HasValue) workOrder.ScheduledEndDate = request.ScheduledEndDate;
        if (request.ModifiedEndDate.HasValue) workOrder.ModifiedEndDate = request.ModifiedEndDate;
        if (request.ProjectId.HasValue) workOrder.ProjectId = request.ProjectId;

        await _repository.UpdateWorkOrderAsync(workOrder, cancellationToken);
        return workOrder;
    }
}
