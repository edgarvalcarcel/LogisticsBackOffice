using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;

internal class GeographicalInfoRepository : IGeographicalInfoRepository
{
    private readonly ApplicationDbContext _context;

    public GeographicalInfoRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddGeographicalInfoAsync(GeographicalInfo geographicalInfo, CancellationToken cancellationToken)
    {
        await _context.GeographicalInfo.AddAsync(geographicalInfo, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<GeographicalInfo> GetAllGeographicalInfo()
    {
        return _context.GeographicalInfo
            .AsQueryable()
            .AsNoTracking();
    }

    public async Task<GeographicalInfo?> FindGeographicalInfoByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.GeographicalInfo.FirstOrDefaultAsync(
            t => t.Id == id, cancellationToken);
    }

    public async Task UpdateGeographicalInfoAsync(GeographicalInfo geographicalInfo, CancellationToken cancellationToken)
    {
        _context.GeographicalInfo.Update(geographicalInfo);
        await _context.SaveChangesAsync(cancellationToken);
    }
}