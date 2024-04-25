using LogisticsBackOffice.Application.Contacts.Queries.GetContacts;
using LogisticsBackOffice.Application.Contacts.Queries.GetWorkerById;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries.Contacts;

[QueryType]
public class ContactQuery
{
    [UseProjection]
    [HotChocolate.Data.UseSingleOrDefault]
    public async Task<ContactDto?> GetContact(int contactId, [Service] IMediator mediator)
    {
        var result = await mediator.Send(new GetContactByIdQuery(contactId));
        return result;
    }
    [HotChocolate.Data.UseSorting]
    [HotChocolate.Data.UseFiltering]
    public async Task<IList<ContactDto>> GetContacts([Service(ServiceKind.Synchronized)] IMediator mediator)
    {
        return await mediator.Send(new GetContactsQuery());
    }
}
