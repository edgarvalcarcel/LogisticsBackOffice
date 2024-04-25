using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ArgumentNullException = LogisticsBackOffice.Application.Common.Exceptions.ArgumentNullException;


namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class WorkOrderRepository(IRepositoryAsync<WorkOrder> workOrderRepository,
ApplicationDbContext dbContext) : IWorkOrderRepository
{
    public IQueryable<WorkOrder> GetAll => throw new NotImplementedException();

    public async Task<WorkOrder?> AddWorkOrderAsync(WorkOrder workOrder)
    {
        return await workOrderRepository.AddAsync(workOrder);
    }

    public Task DeleteWorkOrderAsync(WorkOrder workOrder)
    {
        return workOrderRepository.DeleteAsync(workOrder);
    }

    public async Task<List<WorkOrder?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await workOrderRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }

    public async Task<WorkOrder?> GetWorkOrderByIdAsync(int id)
    {
        var resultWorkOrder = new WorkOrder();
        resultWorkOrder = await dbContext.WorkOrder
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Include(w => w.Service)
            .Include(w => w!.Status)
             .Include(w => w!.Project).ThenInclude(p => p.GeographicalInfo)
            .OrderBy(c => c.Id).DefaultIfEmpty()
             .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(WorkOrder), id);
        return resultWorkOrder;
    }

    public async Task<List<WorkOrder?>> GeWorkOrderAllAsync()
    {
        List<WorkOrder?> resultWorkOrders = [];
        resultWorkOrders = await dbContext.WorkOrder
         .Include(w => w.Service)
         .Include(w => w!.Status)
         .Include(w => w!.Project).ThenInclude(p => p.GeographicalInfo)
         .AsNoTracking().OrderBy(c => c.Id).DefaultIfEmpty().ToListAsync() ?? resultWorkOrders;
        return resultWorkOrders;
    }

    public WorkOrder UpdateWorkOrderAsync(WorkOrder workOrder)
    {
        ArgumentNullException.ThrowIfNull(workOrder);
        return workOrderRepository.Update(workOrder);
    }
}
