using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrderById;
public class GetWorkOrderByIdQueryHandler : IRequestHandler<GetWorkOrderByIdQuery, WorkOrder>
{
    private readonly IWorkOrderByIdDataLoader _dataLoader;
    public GetWorkOrderByIdQueryHandler(IWorkOrderByIdDataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }
    public async Task<WorkOrder> Handle(GetWorkOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dataLoader.LoadAsync(request.Id, cancellationToken);
    }
}
