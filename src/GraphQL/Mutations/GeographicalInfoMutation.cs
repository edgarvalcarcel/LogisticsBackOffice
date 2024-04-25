using HotChocolate.Subscriptions;
using MediatR;
namespace LogisticsBackOffice.GraphQL.Mutations;
public record GeographicalInfoCreatedPayload(int GeographicalInfoId);
[MutationType]
public class GeographicalInfoMutation
{
    public async Task<CreateGeographicalInfoPayload> CreateRole(CreateGeographicalInfoCommand input, [Service] ISender sender, [Service] ITopicEventSender topicEventSender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(topicEventSender);
        var result = await sender.Send(input);
        await topicEventSender.SendAsync(nameof(CreateGeographicalInfo), new GeographicalInfoCreatedPayload(result.GeographicalInfo.Id));
        return result;
    }
    public async Task<ModifyGeographicalInfoPayload> ModifyRole(ModifyGeographicalInfoCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
    public async Task<DeleteGeographicalInfoPayload> DeleteService(DeleteGeographicalInfoCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
}

