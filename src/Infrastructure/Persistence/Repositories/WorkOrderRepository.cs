using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;

internal class WorkOrderRepository : IWorkOrderRepository
{
    private readonly ApplicationDbContext _context;

    public WorkOrderRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddWorkOrderAsync(WorkOrder workOrder, CancellationToken cancellationToken)
    {
        await _context.WorkOrders.AddAsync(workOrder, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<WorkOrder> GetAllWorkOrders()
    {
        return _context.WorkOrders
            .AsQueryable()
            .AsNoTracking();
    }

    public async Task<WorkOrder?> FindWorkOrderByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.WorkOrders.FirstOrDefaultAsync(
            t => t.Id == id, cancellationToken);
    }

    public async Task UpdateWorkOrderAsync(WorkOrder workOrder, CancellationToken cancellationToken)
    {
        _context.WorkOrders.Update(workOrder);
        await _context.SaveChangesAsync(cancellationToken);
    }
   }