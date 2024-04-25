using HotChocolate.Subscriptions;
using LogisticsBackOffice.Application.Roles.Commands.Create;
using LogisticsBackOffice.Application.Roles.Commands.Delete;
using LogisticsBackOffice.Application.Roles.Commands.Modify;
using MediatR;
namespace LogisticsBackOffice.GraphQL.Mutations;
public record RoleCreatedPayload(int RoleId);
[MutationType]
public class RoleMutation
{
    public async Task<CreateRolePayload> CreateRole(CreateRoleCommand input, [Service] ISender sender, [Service] ITopicEventSender topicEventSender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(topicEventSender);
        var result = await sender.Send(input);
        await topicEventSender.SendAsync(nameof(CreateRole), new RoleCreatedPayload(result.Role.Id));
        return result;
    }
    public async Task<ModifyRolePayload> ModifyRole(ModifyRoleCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
    public async Task<DeleteRolePayload> DeleteService(DeleteRoleCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
}
