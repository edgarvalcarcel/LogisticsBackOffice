using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Queries.GetContacts;

public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, IQueryable<Contact>>
{
    private readonly IContactRepository _repository;
    public GetContactsQueryHandler(IContactRepository repository)
    {
        _repository = repository;
    }
    public async Task<IQueryable<Contact>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAllContacts()
            .OrderBy(t => t.FullName);
    }
}
