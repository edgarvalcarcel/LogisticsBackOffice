using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using GreenDonut;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LogisticsBackOffice.Infrastructure.Persistence.DataLoaders;

internal class WorkOrderByIdDataLoader : BatchDataLoader<int, WorkOrder>, IWorkOrderByIdDataLoader
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public WorkOrderByIdDataLoader(
        IDbContextFactory<ApplicationDbContext> dbContextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions options)
        : base(batchScheduler, options)
    {
        _dbContextFactory = dbContextFactory ??
                            throw new ArgumentNullException(nameof(dbContextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, WorkOrder>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var dbContext =
            await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.WorkOrders
            .Where(w => keys.Contains(w.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}