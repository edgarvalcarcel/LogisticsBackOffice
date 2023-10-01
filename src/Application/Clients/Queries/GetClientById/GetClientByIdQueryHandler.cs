using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Queries.GetClientById;

public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
{
    private readonly IClientByIdDataLoader _dataLoader;
    public GetClientByIdQueryHandler(IClientByIdDataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }
    public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dataLoader.LoadAsync(request.Id, cancellationToken);
    }
}
