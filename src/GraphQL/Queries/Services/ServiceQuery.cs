using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.Services.Queries.GetServiceById;
using LogisticsBackOffice.Application.Services.Queries.GetServices;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries.Services;

[QueryType]
public class ServiceQuery
{
    [UseProjection]
    [HotChocolate.Data.UseSingleOrDefault]
    public async Task<ServiceDto?> GetService(int serviceId, [Service] IMediator mediator)
    {
        var result = await mediator.Send(new GetServiceByIdQuery(serviceId));
        return result;
    }
    [HotChocolate.Data.UseSorting]
    [HotChocolate.Data.UseFiltering]
    public async Task<IList<ServiceDto>> GetServices([Service(ServiceKind.Synchronized)] IMediator mediator)
    {
        return await mediator.Send(new GetServicesQuery());
    }
}
