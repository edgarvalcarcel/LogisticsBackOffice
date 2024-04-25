using LogisticsBackOffice.Domain.Entities;
namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IWorkOrderDetailRepository
{
    IQueryable<WorkOrderDetail> GetAll { get; }
    Task<WorkOrderDetail?> GetWorkOrderDetailByIdAsync(int id);
    WorkOrderDetail? GetWorkOrderDetail(int workerId, int workOrderId);
    Task<List<WorkOrderDetail>> GetWorkOrderDetailAllAsync();
    Task<List<WorkOrderDetail?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<WorkOrderDetail> AddWorkOrderDetailAsync(WorkOrderDetail workOrderDetail);
    WorkOrderDetail UpdateWorkOrderDetailAsync(WorkOrderDetail workOrderDetail);
    Task DeleteWorkOrderDetailAsync(WorkOrderDetail workOrderDetail);
}
