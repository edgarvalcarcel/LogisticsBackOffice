using LogisticsBackOffice.Application.Clients.Queries.GetClientById;
using LogisticsBackOffice.Application.Clients.Queries.GetClients;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries.Clients;

[QueryType]
public class ClientQuery
{
    [UseProjection]
    [HotChocolate.Data.UseSingleOrDefault]
    public async Task<ClientDto?> GetClient(int clientId, [Service] IMediator mediator)
    {
        var result = await mediator.Send(new GetClientByIdQuery(clientId));
        return result;
    }
    [HotChocolate.Data.UseSorting]
    [HotChocolate.Data.UseFiltering]
    public async Task<IList<ClientDto>> GetClients([Service(ServiceKind.Synchronized)] IMediator mediator)
    {
        return await mediator.Send(new GetClientsQuery());
    }
}
