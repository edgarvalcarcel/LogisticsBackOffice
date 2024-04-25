using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Queries.GetClients;
public record GetClientsQuery() : IRequest<IList<ClientDto>>;
public record GetClientsPayloadResponse(IList<ClientDto?> Clients);
public class GetClientsQueryHandler(IClientRepository repository, IMapper mapper) : IRequestHandler<GetClientsQuery, IList<ClientDto>>
{
    public async Task<IList<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetClientAllAsync();
        return entities.Select(mapper.Map<ClientDto>).ToList();
    }
}