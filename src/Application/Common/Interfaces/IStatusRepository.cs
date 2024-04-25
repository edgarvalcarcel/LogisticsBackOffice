using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IStatusRepository
{
    Status GetStatus(string entity, int order);
    IQueryable<Status> GetAll { get; }
    Task<Status?> GetStatusByIdAsync(int id);
    Task<List<Status>> GetStatusAllAsync();
    Task<List<Status?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<Status?> AddStatusAsync(Status status);
    Status UpdateStatusAsync(Status status);
    Task DeleteStatusAsync(Status status);
}
