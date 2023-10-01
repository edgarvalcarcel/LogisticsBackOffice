using LogisticsBackOffice.Application.Contacts.Queries.GetContactById;
using LogisticsBackOffice.Application.Contacts.Queries.GetContacts;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries;
[ExtendObjectType(OperationTypeNames.Query)]
public class ContactQueries
{
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<IQueryable<Contact>> GetContactsAsync(
       [Service] IMediator mediator,
       CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetContactsQuery(), cancellationToken);
    }

    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<Contact> GetContactByIdAsync(
    GetContactByIdQuery input,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        return await mediator.Send(input, cancellationToken);
    }
}
