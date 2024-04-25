using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.Workers.Queries.GetWorkerById;
using LogisticsBackOffice.Application.Workers.Queries.GetWorkers;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries.Clients;

[QueryType]
public class WorkerQuery
{
    [UseProjection]
    [HotChocolate.Data.UseSingleOrDefault]
    public async Task<WorkerDto?> GetWorker(int workerId, [Service] IMediator mediator)
    {
        var result = await mediator.Send(new GetWorkerByIdQuery(workerId));
        return result;
    }
    [UseProjection]
    [HotChocolate.Data.UseSorting]
    [HotChocolate.Data.UseFiltering]
    public async Task<IList<WorkerDto>> GetWorkers([Service(ServiceKind.Synchronized)] IMediator mediator)
    {
        return await mediator.Send(new GetWorkersQuery());
    }
}
