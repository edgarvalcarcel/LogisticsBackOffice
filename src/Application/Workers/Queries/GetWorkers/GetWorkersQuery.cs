using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.Workers.Queries.GetWorkers;
public record GetWorkersQuery() : IRequest<IList<WorkerDto>>;
public record GetWorkersPayloadResponse(IList<WorkerDto?> Clients);
public class GetWorkersQueryHandler(IWorkerRepository repository, IMapper mapper) :IRequestHandler<GetWorkersQuery, IList<WorkerDto>>
{
    public async Task<IList<WorkerDto>> Handle(GetWorkersQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetWorkerAllAsync();
        return entities.Select(mapper.Map<WorkerDto>).ToList();
    }
}