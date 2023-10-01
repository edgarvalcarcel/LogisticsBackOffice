using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;

internal class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddServiceAsync(Service service, CancellationToken cancellationToken)
    {
        await _context.Services.AddAsync(service, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Service> GetAllServices()
    {
        return _context.Services
            .AsQueryable()
            .AsNoTracking();
    }

    public async Task<Service?> FindServiceByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Services.FirstOrDefaultAsync(
            t => t.Id == id, cancellationToken);
    }

    public async Task UpdateServiceAsync(Service service, CancellationToken cancellationToken)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync(cancellationToken);
    }
}