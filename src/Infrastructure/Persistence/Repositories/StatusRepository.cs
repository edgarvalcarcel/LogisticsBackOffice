using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using ArgumentNullException = LogisticsBackOffice.Application.Common.Exceptions.ArgumentNullException;
namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class StatusRepository(IRepositoryAsync<Status> statusRepository, ApplicationDbContext dbContext) : IStatusRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    IQueryable<Status> IStatusRepository.GetAll => statusRepository.Entities;
    public Status GetStatus(string entity, int order)
    {
        var status = new Status();
        status = _dbContext.Status.Where(g => g.Entity == entity && g.Order == order)
            .FirstOrDefault() ?? throw new NotFoundException(nameof(Status), entity);
        return status;
    }
    public async Task<Status?> AddStatusAsync(Status status)
    {
        return await statusRepository.AddAsync(status);
    }
    public Task DeleteStatusAsync(Status status)
    {
        return statusRepository.DeleteAsync(status);
    }
    public async Task<List<Status?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await statusRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }
    public async Task<List<Status>> GetStatusAllAsync()
    {
        var resultStatuses = statusRepository.GetAllAsync() ?? throw new NotFoundException(nameof(List<Status>));
        return await resultStatuses;
    }
    public async Task<Status?> GetStatusByIdAsync(int id)
    {
        var resultService = await statusRepository.GetByIdAsync(id) ?? throw new NotFoundException(nameof(Status), id);
        return resultService;
    }
    public Status UpdateStatusAsync(Status status)
    {
        ArgumentNullException.ThrowIfNull(status);
        return statusRepository.Update(status);
    }
}
