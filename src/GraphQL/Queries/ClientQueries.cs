using LogisticsBackOffice.Application.Clients.Queries.GetClientById;
using LogisticsBackOffice.Application.Clients.Queries.GetClients;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries;
[ExtendObjectType(OperationTypeNames.Query)]

public class ClientQueries
{
    //[UsePaging]
    //[UseProjection]
    //[HotChocolate.Data.UseFiltering]
    //[HotChocolate.Data.UseSorting]
    public async Task<IEnumerable<Client>> GetClientsAsync(
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetClientsQuery(), cancellationToken);
    }
    //[UsePaging]
    //[UseProjection]
    //[HotChocolate.Data.UseFiltering]
    //[HotChocolate.Data.UseSorting]

    public async Task<Client> GetClientByIdAsync(
        GetClientByIdQuery input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(input, cancellationToken);
    }
}
