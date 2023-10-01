using GreenDonut;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.DataLoaders
{
    internal class GeographicalInfoByIdDataLoader : BatchDataLoader<int, GeographicalInfo>, IGeographicalInfoByIdDataLoader
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public GeographicalInfoByIdDataLoader(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options)
            : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory ??
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, GeographicalInfo>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using var dbContext =
                await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            return await dbContext.GeographicalInfo
                .Where(g => keys.Contains(g.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
