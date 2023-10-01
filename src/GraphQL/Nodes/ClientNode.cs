using LogisticsBackOffice.Application.Clients.Queries.GetClientById;
using LogisticsBackOffice.Application.Clients.Queries.GetClients;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Nodes;
[Node]
[ExtendObjectType]
public class ClientNode
{
    public async Task<IEnumerable<Client>> GetClientsAsync(
    [Parent] Client client,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetClientsQuery(), cancellationToken);
    }

    [NodeResolver]
    public static Task<Client> GetClientAsync(
     GetClientByIdQuery input,
     [Service] IMediator mediator,
     CancellationToken cancellationToken)
    {
        return mediator.Send(input, cancellationToken);
    }
}
