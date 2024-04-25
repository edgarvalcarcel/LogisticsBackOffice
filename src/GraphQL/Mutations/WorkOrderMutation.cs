using HotChocolate.Subscriptions;
using LogisticsBackOffice.Application.WorkOrders.Command.Create;
using LogisticsBackOffice.Application.WorkOrders.Command.Delete;
using LogisticsBackOffice.Application.WorkOrders.Command.Modify;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;
public record WorkOrderCreatedPayload(int WorkOrderId);

[MutationType]
public class WorkOrderMutation
{
    public async Task<CreateWorkOrderPayload> CreateWorkOrder(CreateWorkOrderCommand input, [Service] ISender sender, [Service] ITopicEventSender topicEventSender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(topicEventSender);
        var result = await sender.Send(input);
        await topicEventSender.SendAsync(nameof(CreateWorkOrder), new WorkOrderCreatedPayload(result.WorkOrder.Id));
        return result;
    }
    public async Task<ModifyWorkOrderPayload> ModifyWorkOrder(ModifyWorkOrderCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
    public async Task<DeleteWorkOrderPayload> DeleteWorkOrder(DeleteWorkOrderCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
}