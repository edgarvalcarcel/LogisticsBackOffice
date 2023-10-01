using LogisticsBackOffice.Application.Services.Queries.GetServiceById;
using LogisticsBackOffice.Application.Services.Queries.GetServices;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries;
[ExtendObjectType(OperationTypeNames.Query)]
public class ServiceQueries
{
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<IQueryable<Service>> GetServicesAsync(
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetServicesQuery(), cancellationToken);
    }
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<Service> GetServiceByIdAsync(
        GetServiceByIdQuery input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(input, cancellationToken);
    }
}
