using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class WorkOrderDetailRepository(IRepositoryAsync<WorkOrderDetail> workOrderDetailRepository,
    ApplicationDbContext dbContext) : IWorkOrderDetailRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    public IQueryable<WorkOrderDetail> GetAll => workOrderDetailRepository.Entities;

    public async Task<WorkOrderDetail> AddWorkOrderDetailAsync(WorkOrderDetail workOrderDetail)
    {
        return await workOrderDetailRepository.AddAsync(workOrderDetail);
    }

    public Task DeleteWorkOrderDetailAsync(WorkOrderDetail workOrderDetail)
    {
        return workOrderDetailRepository.DeleteAsync(workOrderDetail);
    }

    public async Task<List<WorkOrderDetail?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await workOrderDetailRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }

    public WorkOrderDetail? GetWorkOrderDetail(int workerId, int workOrderId)
    {
        if (workerId != 0 && workOrderId != 0)
        {
            var resultWorkOrderDetail = _dbContext.WorkOrderDetail
            .AsNoTracking()
            .Where(p => p.WorkOrderId == workOrderId && p.WorkerId == workerId)
            .Include(p => p.Worker)
            .Include(p => p.Staff)
            .OrderBy(p => p.Id).FirstOrDefault();
            return resultWorkOrderDetail;
        }
        return null;
    }

    public async Task<List<WorkOrderDetail>> GetWorkOrderDetailAllAsync()
    {
        var resultWorkOrderDetails = new List<WorkOrderDetail>();
        resultWorkOrderDetails = await _dbContext.WorkOrderDetail
            .Include(p => p.Worker)
            .Include(p => p.Staff)
            .AsNoTracking()
            .OrderBy(p => p.Id).ToListAsync() ?? throw new NotFoundException(nameof(List<WorkOrderDetail>));
        return resultWorkOrderDetails;
    }

    public async Task<WorkOrderDetail?> GetWorkOrderDetailByIdAsync(int id)
    {
        var resultProjectDetail = await _dbContext.WorkOrderDetail
        .Include(p => p.Worker)
        .Include(p => p.Staff)
        .AsNoTracking()
        .OrderBy(p => p.Id).FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(WorkOrderDetail), id);
        return resultProjectDetail;
    }

    public WorkOrderDetail UpdateWorkOrderDetailAsync(WorkOrderDetail workOrderDetail)
    {
        return workOrderDetailRepository.Update(workOrderDetail);
    }
}
