using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IWorkOrderRepository
{
    IQueryable<WorkOrder> GetAll { get; }
    Task<WorkOrder?> GetWorkOrderByIdAsync(int id);
    Task<List<WorkOrder?>> GeWorkOrderAllAsync();
    Task<List<WorkOrder?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<WorkOrder?> AddWorkOrderAsync(WorkOrder workOrder);
    WorkOrder UpdateWorkOrderAsync(WorkOrder workOrder);
    Task DeleteWorkOrderAsync(WorkOrder workOrder);
}
