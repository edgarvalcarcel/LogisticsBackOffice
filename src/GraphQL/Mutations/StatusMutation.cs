using HotChocolate.Subscriptions;
using LogisticsBackOffice.Application.Statuses.Commands.Create;
using LogisticsBackOffice.Application.Statuses.Commands.Delete;
using LogisticsBackOffice.Application.Statuses.Commands.Modify;
using MediatR;
namespace LogisticsBackOffice.GraphQL.Mutations;
public record StatusCreatedPayload(int StatusId);
[MutationType]
public class StatusMutation
{
    public async Task<CreateStatusPayload> CreateStatus(CreateStatusCommand input, [Service] ISender sender, [Service] ITopicEventSender topicEventSender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(topicEventSender);
        var result = await sender.Send(input);
        await topicEventSender.SendAsync(nameof(CreateStatus), new StatusCreatedPayload(result.Status.Id));
        return result;
    }
    public async Task<ModifyStatusPayload> ModifyStatus(ModifyStatusCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
    public async Task<DeleteStatusPayload> DeleteStatus(DeleteStatusCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
}
