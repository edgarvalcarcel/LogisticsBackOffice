using HotChocolate.Subscriptions;
using LogisticsBackOffice.Application.Workers.Commands.Create;
using LogisticsBackOffice.Application.Workers.Commands.Delete;
using LogisticsBackOffice.Application.Workers.Commands.Modify;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;
public record WorkerCreatedPayload(int ClientId);

[MutationType]
public class WorkerMutation
{
    public async Task<CreateWorkerPayload> CreateWorker(CreateWorkerCommand input, [Service] ISender sender, [Service] ITopicEventSender topicEventSender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(topicEventSender);
        var result = await sender.Send(input);
        await topicEventSender.SendAsync(nameof(CreateWorker), new WorkerCreatedPayload(result.Worker.Id));
        return result;
    }
    public async Task<ModifyWorkerPayload> ModifyWorker(ModifyWorkerCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
    public async Task<DeleteWorkerPayload> DeleteWorker(DeleteWorkerCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
}