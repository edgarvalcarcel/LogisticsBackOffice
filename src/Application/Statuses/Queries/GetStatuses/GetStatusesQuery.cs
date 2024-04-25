using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.Statuses.Queries.GetStatuses;
public record GetStatusesQuery() : IRequest<IList<StatusDto>>;
public record GetStatusesPayloadResponse(IList<StatusDto?> Clients);
public class GetStatusesQueryHandler(IStatusRepository repository, IMapper mapper) : IRequestHandler<GetStatusesQuery, IList<StatusDto>>
{
    public async Task<IList<StatusDto>> Handle(GetStatusesQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetStatusAllAsync();
        return entities.Select(mapper.Map<StatusDto>).ToList();
    }
}
