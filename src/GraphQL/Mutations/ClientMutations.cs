using LogisticsBackOffice.Application.Clients.Commands.AddClient;
using LogisticsBackOffice.Application.Clients.Commands.ModifyClient;
using LogisticsBackOffice.Domain.Common;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class ClientMutations
{
    public async Task<AddClientPayload> AddClientAsync(
    AddClientCommand input,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        var client = await mediator.Send(input, cancellationToken);
        return new AddClientPayload(client);
    }

    public async Task<ModifyClientPayload> ModifyClientAsync(
         ModifyClientCommand input,
         [Service] IMediator mediator,
         CancellationToken cancellationToken)
    {
        if (input.FirstName.HasValue && input.FirstName.Value is null)
            return new ModifyClientPayload(
                new UserError("First Name cannot be null", "NAME_NULL"));

        var client = await mediator.Send(input, cancellationToken);

        if (client is null)
            return new ModifyClientPayload(
                new UserError("Client with id not found.", "CLIENT_NOT_FOUND"));

        return new ModifyClientPayload(client);
    }
}
