using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IWorkOrderRepository
{
    Task AddWorkOrderAsync(WorkOrder workOrder, CancellationToken cancellationToken);
    IQueryable<WorkOrder> GetAllWorkOrders();
    Task<WorkOrder?> FindWorkOrderByIdAsync(int id, CancellationToken cancellationToken);
    Task UpdateWorkOrderAsync(WorkOrder workOrder, CancellationToken cancellationToken);
}