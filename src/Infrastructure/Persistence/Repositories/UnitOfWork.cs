using LogisticsBackOffice.Application.Common.Interfaces;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    //private readonly IAuthenticatedUserService _authenticatedUserService;
    private readonly ApplicationDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private bool _disposed;

    public async Task<int> Commit()
    {
        return await _dbContext.SaveChangesAsync();
    }
    public Task Rollback()
    {
        return Task.CompletedTask;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        _disposed = true;
    }
}
