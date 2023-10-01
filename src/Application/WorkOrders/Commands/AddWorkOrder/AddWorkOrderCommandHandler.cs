using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Commands.AddWorkOrder;
public class AddWorkOrderCommandHandler : IRequestHandler<AddWorkOrderCommand, WorkOrder>
{
    private readonly IWorkOrderRepository _repository;

    public AddWorkOrderCommandHandler(IWorkOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<WorkOrder> Handle(AddWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var workOrder = new WorkOrder
        {
            ProjectDetailId = request.ProjectDetailId,
            ServiceId = request.ServiceId,
            OperatorId = request.OperatorId,
            HoursAmount = request.HoursAmount,
            ScheduledStartDate = request.ScheduledStartDate,
            ScheduledEndDate = request.ScheduledEndDate,
            ModifiedEndDate = request.ModifiedEndDate
        };
        await _repository.AddWorkOrderAsync(workOrder, cancellationToken);
        return workOrder;
    }
}