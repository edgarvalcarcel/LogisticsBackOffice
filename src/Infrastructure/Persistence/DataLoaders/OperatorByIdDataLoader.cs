using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using GreenDonut;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.DataLoaders;

internal class OperatorByIdDataLoader : BatchDataLoader<int, Operator>, IOperatorByIdDataLoader
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public OperatorByIdDataLoader(
        IDbContextFactory<ApplicationDbContext> dbContextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions options)
        : base(batchScheduler, options)
    {
        _dbContextFactory = dbContextFactory ??
                            throw new ArgumentNullException(nameof(dbContextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Operator>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var dbContext =
            await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Operators
            .Where(o => keys.Contains(o.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}