using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrders;
public record GetWorkOrdersQuery() : IRequest<IList<WorkOrderDto>>;
public record GetWorkOrdersPayloadResponse(IList<WorkOrderDto?> Clients);
public class GetWorkOrdersQueryHandler(IWorkOrderRepository repository, IMapper mapper) : IRequestHandler<GetWorkOrdersQuery, IList<WorkOrderDto>>
{
    public async Task<IList<WorkOrderDto>> Handle(GetWorkOrdersQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GeWorkOrderAllAsync();
        return entities.Select(mapper.Map<WorkOrderDto>).ToList();
    }
}