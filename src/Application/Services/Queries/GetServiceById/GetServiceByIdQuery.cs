using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.Services.Queries.GetServiceById;
public record GetServiceByIdQuery(int Id) : IRequest<ServiceDto?>;
public class GetServiceByIdQueryHandler(IServiceRepository repository, IMapper mapper) : IRequestHandler<GetServiceByIdQuery, ServiceDto?>
{
    public async Task<ServiceDto?> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var service = await repository.GetServiceByIdAsync(request.Id);
        return mapper.Map<ServiceDto>(service);
    }
}