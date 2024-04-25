using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;
namespace LogisticsBackOffice.Application.Services.Queries.GetServices;
public record GetServicesQuery() : IRequest<IList<ServiceDto>>;
public record GetServicesPayloadResponse(IList<ServiceDto?> Clients);
public class GetServicesQueryHandler(IServiceRepository repository, IMapper mapper) : IRequestHandler<GetServicesQuery, IList<ServiceDto>>
{
    public async Task<IList<ServiceDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetServiceAllAsync();
        return entities.Select(mapper.Map<ServiceDto>).ToList();
    }
}
