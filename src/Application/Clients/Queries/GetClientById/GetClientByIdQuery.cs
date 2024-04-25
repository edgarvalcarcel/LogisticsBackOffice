using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Queries.GetClientById;
public record GetClientByIdQuery(int Id) : IRequest<ClientDto?>;
public class GetClientByIdQueryHandler(IClientRepository repository, IMapper mapper) : IRequestHandler<GetClientByIdQuery, ClientDto?>
{
    public async Task<ClientDto?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var client = await repository.GetClientByIdAsync(request.Id);
        return mapper.Map<ClientDto>(client);
    }
}