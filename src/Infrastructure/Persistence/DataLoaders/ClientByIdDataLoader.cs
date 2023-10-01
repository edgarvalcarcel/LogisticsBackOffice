using GreenDonut;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.DataLoaders;

internal class ClientByIdDataLoader : BatchDataLoader<int, Client>, IClientByIdDataLoader
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public ClientByIdDataLoader(
        IDbContextFactory<ApplicationDbContext> dbContextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions options)
        : base(batchScheduler, options)
    {
        _dbContextFactory = dbContextFactory ??
                            throw new ArgumentNullException(nameof(dbContextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Client>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using var dbContext =
            await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Clients
            .Where(c => keys.Contains(c.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
