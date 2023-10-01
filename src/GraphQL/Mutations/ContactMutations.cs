using LogisticsBackOffice.Application.Contacts.Commands.AddContact;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class ContactMutations
{
    public async Task<AddContactPayload> AddContactAsync(
    AddContactCommand input,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        var contact = await mediator.Send(input, cancellationToken);
        return new AddContactPayload(contact);
    }
}
