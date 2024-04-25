using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ArgumentNullException = LogisticsBackOffice.Application.Common.Exceptions.ArgumentNullException;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class WorkerRepository(IRepositoryAsync<Worker> workerRepository,
    IRepositoryAsync<GeographicalInfo> geographicalRepository, ApplicationDbContext dbContext) : IWorkerRepository
{
    private readonly IRepositoryAsync<Worker> _workerRepository = workerRepository;
    private readonly IRepositoryAsync<GeographicalInfo> _geographicalRepository = geographicalRepository;
    private readonly ApplicationDbContext _dbContext = dbContext;
    public IQueryable<Worker> GetAll => _workerRepository.Entities;

    public async Task<Worker?> AddWorkerAsync(Worker worker)
    {
        return await _workerRepository.AddAsync(worker);
    }

    public Task DeleteWorkerAsync(Worker worker)
    {
        return _workerRepository.DeleteAsync(worker);
    }

    public async Task<List<Worker?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await _workerRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }

    public async Task<List<Worker>> GetWorkerAllAsync()
    {
        var resultWorkers = await _dbContext.Worker
          .Include(c => c.GeographicalInfo)
          .ThenInclude(g => g!.State).ThenInclude(s => s!.CountryRegion)
          .AsNoTracking()
          .OrderBy(c => c.Id).DefaultIfEmpty().ToListAsync() ?? throw new NotFoundException(nameof(List<Worker>));
        return resultWorkers;
    }

    public async Task<Worker?> GetWorkerByIdAsync(int id)
    {
        var resultWorker = await _dbContext.Worker.Where(c => c.Id == id)
           .Include(c => c.GeographicalInfo)
           .ThenInclude(g => g!.State).ThenInclude(s => s!.CountryRegion)
            .AsNoTracking()
           .OrderBy(c => c.Id).DefaultIfEmpty()
           .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Worker), id);
        return resultWorker;
    }

    public Worker UpdateWorkerAsync(Worker worker)
    {
        ArgumentNullException.ThrowIfNull(worker);
        ArgumentNullException.ThrowIfNull(worker.GeographicalInfo);
        _geographicalRepository.Update(worker.GeographicalInfo);
        return _workerRepository.Update(worker);
    }
}
