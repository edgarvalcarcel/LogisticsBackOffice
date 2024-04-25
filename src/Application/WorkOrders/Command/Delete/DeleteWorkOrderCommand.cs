using AutoMapper;
using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Events.WorkOrderEvents;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Command.Delete;
public record DeleteWorkOrderCommand(int Id) : IRequest<DeleteWorkOrderPayload>;
public record DeleteWorkOrderPayload(WorkOrderDto WorkOrder);
public class DeleteWorkOrderCommandHandler : IRequestHandler<DeleteWorkOrderCommand, DeleteWorkOrderPayload>
{
    private readonly IWorkOrderRepository _workOrderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeleteWorkOrderCommandHandler(IWorkOrderRepository workOrderRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    {
        _workOrderRepository = workOrderRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<DeleteWorkOrderPayload> Handle(DeleteWorkOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _workOrderRepository.GetWorkOrderByIdAsync(request.Id) ?? throw new NotFoundException(nameof(ProjectDto), request.Id);
        await _workOrderRepository.DeleteWorkOrderAsync(entity);
        entity.AddDomainEvent(new WorkOrderDeletedEvent(entity));
        await _unitOfWork.Commit();
        return new DeleteWorkOrderPayload(_mapper.Map<WorkOrderDto>(entity));
    }
}
