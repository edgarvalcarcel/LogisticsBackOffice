using HotChocolate.Subscriptions;
using LogisticsBackOffice.Application.Contacts.Commands.Create;
using LogisticsBackOffice.Application.Contacts.Commands.Delete;
using LogisticsBackOffice.Application.Contacts.Commands.Modify;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;
public record ContactCreatedPayload(int ContactId);

[MutationType]
public class ContactMutation
{
    public async Task<CreateContactPayload> CreateContact(CreateContactCommand input, [Service] ISender sender, [Service] ITopicEventSender topicEventSender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(topicEventSender);
        var result = await sender.Send(input);
        await topicEventSender.SendAsync(nameof(CreateContact), new ContactCreatedPayload(result.Worker.Id));
        return result;
    }
    public async Task<ModifyContactPayload> ModifyWorker(ModifyContactCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
    public async Task<DeleteContactPayload> DeleteWorker(DeleteContactCommand input, [Service] ISender sender)
    {
        ArgumentNullException.ThrowIfNull(sender);
        return await sender.Send(input);
    }
}