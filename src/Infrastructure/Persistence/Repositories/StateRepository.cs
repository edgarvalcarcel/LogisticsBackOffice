using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;

internal class StateRepository : IStateRepository
{
    private readonly ApplicationDbContext _context;
    public StateRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddStateAsync(State state, CancellationToken cancellationToken)
    {
        await _context.State.AddAsync(state, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<State> GetAllStates()
    {
        return _context.State
            .AsQueryable()
            .AsNoTracking();
    }

    public async Task<State?> FindStateByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.State.FirstOrDefaultAsync(
            t => t.Id == id, cancellationToken);
    }

    public async Task UpdateStateAsync(State state, CancellationToken cancellationToken)
    {
        _context.State.Update(state);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
