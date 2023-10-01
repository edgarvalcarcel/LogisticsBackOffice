using LogisticsBackOffice.Application.Clients.Queries.GetClientById;
using LogisticsBackOffice.Application.Contacts.Queries.GetContacts;
using LogisticsBackOffice.Application.GeographicalInformation.Queries.GetGeographicalInfoById;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries;
[ExtendObjectType(OperationTypeNames.Query)]
public class GeographicalInfoQueries
{
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<GeographicalInfo> GetGeographicalInfoByIdAsync(
    GetGeographicalInfoByIdQuery input,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        return await mediator.Send(input, cancellationToken);
    }
}
