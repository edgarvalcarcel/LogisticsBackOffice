using LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrderById;
using LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrders;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class WorkOrderQueries
{
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<IQueryable<WorkOrder>> GetWorkOrders(
     [Service] IMediator mediator,
     CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetWorkOrdersQuery(), cancellationToken);
    }
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<WorkOrder> GetWorkOrderByIdAsync(
    GetWorkOrderByIdQuery input,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        return await mediator.Send(input, cancellationToken);
    }
}
