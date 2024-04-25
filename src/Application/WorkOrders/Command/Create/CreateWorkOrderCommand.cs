using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
namespace LogisticsBackOffice.Application.WorkOrders.Command.Create;
public record CreateWorkOrderCommand : IRequest<CreateWorkOrderPayload>
{
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
public record CreateWorkOrderPayload(WorkOrderDto WorkOrder);

public class CreateWorkOrderCommandHandler(IWorkOrderRepository workOrderRepository,
    IUnitOfWork unitOfWork, IMapper mapper, IStatusRepository statusRepository) : IRequestHandler<CreateWorkOrderCommand, CreateWorkOrderPayload>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IWorkOrderRepository _workOrderRepository = workOrderRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<CreateWorkOrderPayload> Handle(CreateWorkOrderCommand request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var entity = _mapper.Map<WorkOrder>(request);
        //var detailList = _mapper.Map<List<WorkOrder>>(request.WorkOrderDetail);
        entity.StatusId = _statusRepository.GetStatus("WorkOrder", 2).Id;
        await _workOrderRepository.AddWorkOrderAsync(entity);
        await _unitOfWork.Commit();
        return new CreateWorkOrderPayload(_mapper.Map<WorkOrderDto>(entity));
    }
}