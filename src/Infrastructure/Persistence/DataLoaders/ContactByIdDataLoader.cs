using GreenDonut;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.DataLoaders
{
    internal class ContactByIdDataLoader : BatchDataLoader<int, Contact>, IContactByIdDataLoader
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public ContactByIdDataLoader(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options)
            : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory ??
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Contact>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using var dbContext =
                await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            return await dbContext.Contacts
                .Where(c => keys.Contains(c.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
