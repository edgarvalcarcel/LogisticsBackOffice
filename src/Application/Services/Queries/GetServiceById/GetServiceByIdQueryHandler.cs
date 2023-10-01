using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Services.Queries.GetServiceById;

public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Service>
{
    private readonly IServiceByIdDataLoader _dataLoader;
    public GetServiceByIdQueryHandler(IServiceByIdDataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }
    public async Task<Service> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dataLoader.LoadAsync(request.Id, cancellationToken);
    }
}


