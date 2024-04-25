using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrderById;
public record GetWorkOrderByIdQuery(int Id) : IRequest<WorkOrderDto?>;
public class GetWorkOrderByIdQueryHandler(IWorkOrderRepository repository, IMapper mapper) : IRequestHandler<GetWorkOrderByIdQuery, WorkOrderDto?>
{
    public async Task<WorkOrderDto?> Handle(GetWorkOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var workOrder = await repository.GetWorkOrderByIdAsync(request.Id);
        return mapper.Map<WorkOrderDto>(workOrder);
    }
}