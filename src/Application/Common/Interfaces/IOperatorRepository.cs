using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IOperatorRepository
{
    Task AddOperatorAsync(Operator _operator, CancellationToken cancellationToken);
    IQueryable<Operator> GetAllOperators();
    Task<Operator?> FindOperatorByIdAsync(int id, CancellationToken cancellationToken);
    Task UpdateOperatorAsync(Operator _operator, CancellationToken cancellationToken);
}