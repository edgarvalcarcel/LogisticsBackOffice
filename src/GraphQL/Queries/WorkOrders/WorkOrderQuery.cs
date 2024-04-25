using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrderById;
using LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrders;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
namespace LogisticsBackOffice.GraphQL.Queries.WorkOrders;
[QueryType]
public class WorkOrderQuery
{
    [UseProjection]
    [HotChocolate.Data.UseSingleOrDefault]
    public async Task<WorkOrderDto?> GetWorkOrder(int workerId, [Service] IMediator mediator)
    {
        var result = await mediator.Send(new GetWorkOrderByIdQuery(workerId));
        return result;
    }
    [UseProjection]
    [HotChocolate.Data.UseSorting]
    [HotChocolate.Data.UseFiltering]
    public async Task<IList<WorkOrderDto>> GetWorkOrders([Service(ServiceKind.Synchronized)] IMediator mediator)
    {
        return await mediator.Send(new GetWorkOrdersQuery());
    }
}
