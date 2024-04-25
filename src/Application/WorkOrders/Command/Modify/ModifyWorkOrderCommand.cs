using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Command.Modify;
public record ModifyWorkOrderCommand : IRequest<ModifyWorkOrderPayload>
{
    public int Id { get; init; }
    public int ProjectId { get; init; }
    public int ProjectDetailId { get; init; }
    public int ServiceId { get; init; }
    public decimal HoursAmount { get; init; }
    public DateTime? ScheduledStartDate { get; init; }
    public DateTime? ScheduledEndDate { get; init; }
    public bool? ReportToStaff { get; init; }
    public int? StaffId { get; init; }
    public IList<WorkOrderDetailDto> WorkOrderDetail { get; init; } = [];
}
public record ModifyWorkOrderPayload(WorkOrderDto WorkOrder);
public class ModifyWorkOrderCommandHandler(
    IWorkOrderRepository workOrderRepository,
    IWorkOrderDetailRepository workOrderDetailRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<ModifyWorkOrderCommand, ModifyWorkOrderPayload>
{
    public async Task<ModifyWorkOrderPayload> Handle(ModifyWorkOrderCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entity = await workOrderRepository.GetWorkOrderByIdAsync(request.Id);
        if (entity is null) return new ModifyWorkOrderPayload(mapper.Map<WorkOrderDto>(entity));

        ArgumentNullException.ThrowIfNull(request.WorkOrderDetail);
        if (entity.WorkOrderDetail.Count >= 0)
        {
            foreach (var item in entity.WorkOrderDetail)
            {
                await workOrderDetailRepository.DeleteWorkOrderDetailAsync(item);
            }
            await unitOfWork.Commit();
            entity.WorkOrderDetail = [];
        }

        ArgumentNullException.ThrowIfNull(request);
        entity = mapper.Map<WorkOrder>(request);

        ArgumentNullException.ThrowIfNull(request.WorkOrderDetail);
        if (request.WorkOrderDetail != null && request.WorkOrderDetail.Any())
        {
            entity.WorkOrderDetail = request.WorkOrderDetail != null
            ? request.WorkOrderDetail.Select(item => mapper.Map<WorkOrderDetail>(item)).ToList()
            : [];
            foreach (var item in entity.WorkOrderDetail)
            {
                item.WorkOrderId = entity.Id;
                await workOrderDetailRepository.AddWorkOrderDetailAsync(item);
            }
        }
        workOrderRepository.UpdateWorkOrderAsync(entity);
        await unitOfWork.Commit();
        return new ModifyWorkOrderPayload(mapper.Map<WorkOrderDto>(entity));
    }
}

