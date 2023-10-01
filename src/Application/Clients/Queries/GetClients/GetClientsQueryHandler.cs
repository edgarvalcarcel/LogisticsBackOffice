using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Queries.GetClients;

public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, IEnumerable<Client>>
{
    private readonly IClientRepository _repository;
    public GetClientsQueryHandler(IClientRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Client>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAllClients()
            .OrderBy(t => t.LastName);
    }
}
