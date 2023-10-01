using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrders;

public class GetWorkOrdersQueryHandler : IRequestHandler<GetWorkOrdersQuery, IQueryable<WorkOrder>>
{
    private readonly IWorkOrderRepository _repository;
    public GetWorkOrdersQueryHandler(IWorkOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<IQueryable<WorkOrder>> Handle(GetWorkOrdersQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAllWorkOrders()
            .OrderBy(t => t.Id);
    }
}
