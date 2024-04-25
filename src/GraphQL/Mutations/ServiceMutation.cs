using HotChocolate.Subscriptions;
using LogisticsBackOffice.Application.Services.Commands.Create;
using LogisticsBackOffice.Application.Services.Commands.Delete;
using LogisticsBackOffice.Application.Services.Commands.Modify;
using MediatR;
namespace LogisticsBackOffice.GraphQL.Mutations;
public record ServiceCreatedPayload(int ServiceId);
[MutationType]
public class ServiceMutation
{
    public async Task<CreateServicePayload> CreateService(CreateServiceCommand input, [Service] ISender sender, [Service] ITopicEventSender topicEventSender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(topicEventSender);
        var result = await sender.Send(input);
        await topicEventSender.SendAsync(nameof(CreateService), new ServiceCreatedPayload(result.Service.Id));
        return result;
    }
    public async Task<ModifyServicePayload> ModifyService(ModifyServiceCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
    public async Task<DeleteServicePayload> DeleteService(DeleteServiceCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
}
