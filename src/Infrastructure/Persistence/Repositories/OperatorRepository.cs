using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;

internal class OperatorRepository : IOperatorRepository
{
    private readonly ApplicationDbContext _context;

    public OperatorRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddOperatorAsync(Operator _operator, CancellationToken cancellationToken)
    {
        await _context.Operators.AddAsync(_operator, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Operator> GetAllOperators()
    {
        return _context.Operators
            .AsQueryable()
            .AsNoTracking();
    }

    public async Task<Operator?> FindOperatorByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Operators.FirstOrDefaultAsync(
            t => t.Id == id, cancellationToken);
    }

    public async Task UpdateOperatorAsync(Operator _operator, CancellationToken cancellationToken)
    {
        _context.Operators.Update(_operator);
        await _context.SaveChangesAsync(cancellationToken);
    }
}