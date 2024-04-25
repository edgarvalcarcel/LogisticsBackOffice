using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;
namespace LogisticsBackOffice.Application.Contacts.Queries.GetWorkerById;
public record GetContactByIdQuery(int Id) : IRequest<ContactDto?>;
public class GetContactByIdQueryHandler(IContactRepository repository, IMapper mapper) : IRequestHandler<GetContactByIdQuery, ContactDto?>
{
    public async Task<ContactDto?> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var worker = repository.GetContactById(request.Id);
        return mapper.Map<ContactDto>(worker);
    }
}