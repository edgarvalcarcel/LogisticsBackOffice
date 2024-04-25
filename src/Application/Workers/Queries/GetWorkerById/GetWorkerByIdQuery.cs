using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;
namespace LogisticsBackOffice.Application.Workers.Queries.GetWorkerById;
public record GetWorkerByIdQuery(int id) : IRequest<WorkerDto?>;
public class GetWorkerByIdQueryHandler(IWorkerRepository repository, IMapper mapper) : IRequestHandler<GetWorkerByIdQuery, WorkerDto?>
{
    public async Task<WorkerDto?> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var worker = await repository.GetWorkerByIdAsync(request.id);
        return mapper.Map<WorkerDto>(worker);
    }
}