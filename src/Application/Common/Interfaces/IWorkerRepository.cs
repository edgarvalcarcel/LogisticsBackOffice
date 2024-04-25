using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IWorkerRepository
{
    IQueryable<Worker> GetAll { get; }
    Task<Worker?> GetWorkerByIdAsync(int id);
    Task<List<Worker>> GetWorkerAllAsync();
    Task<List<Worker?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<Worker?> AddWorkerAsync(Worker worker);
    Worker UpdateWorkerAsync(Worker worker);
    Task DeleteWorkerAsync(Worker worker);
}
