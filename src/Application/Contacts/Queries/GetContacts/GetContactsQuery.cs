using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Queries.GetContacts;
public record GetContactsQuery() : IRequest<IList<ContactDto>>;
public record GetContactsPayloadResponse(IList<ContactDto?> Clients);
public class GetContactsQueryHandler(IContactRepository repository, IMapper mapper) : IRequestHandler<GetContactsQuery, IList<ContactDto>>
{
    public async Task<IList<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetContactAllAsync();
        return entities.Select(mapper.Map<ContactDto>).ToList();
    }
}