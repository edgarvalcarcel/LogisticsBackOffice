using HotChocolate.Subscriptions;
using LogisticsBackOffice.Application.Clients.Commands.Create;
using LogisticsBackOffice.Application.Clients.Commands.Delete;
using LogisticsBackOffice.Application.Clients.Commands.Modify;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;

public record ClientCreatedPayload(int ClientId);

[MutationType]
public class ClientMutation
{
    public async Task<CreateClientPayload> CreateClient(CreateClientCommand input, [Service] ISender sender, [Service] ITopicEventSender topicEventSender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(topicEventSender);
        var result = await sender.Send(input);
        await topicEventSender.SendAsync(nameof(CreateClient), new ClientCreatedPayload(result.Client.Id));
        return result;
    }
    public async Task<ModifyClientPayload> ModifyClient(ModifyClientCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
    public async Task<DeleteClientPayload> DeleteClient(DeleteClientCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
}
