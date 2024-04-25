using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using ArgumentNullException = LogisticsBackOffice.Application.Common.Exceptions.ArgumentNullException;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class ServiceRepository(IRepositoryAsync<Service> serviceRepository) : IServiceRepository
{
    private readonly IRepositoryAsync<Service> _serviceRepository = serviceRepository;
    public IQueryable<Service> GetAll => _serviceRepository.Entities;
    public async Task<Service?> AddServiceAsync(Service service)
    {
        return await _serviceRepository.AddAsync(service);
    }
    public async Task<Service?> GetServiceByIdAsync(int id)
    {
        var resultService = await _serviceRepository.GetByIdAsync(id) ?? throw new NotFoundException(nameof(Service), id);
        return resultService;
    }
    public async Task<List<Service?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await _serviceRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }
    public Service UpdateServiceAsync(Service service)
    {
        ArgumentNullException.ThrowIfNull(service);
        return _serviceRepository.Update(service);
    }
    public async Task<List<Service>> GetServiceAllAsync()
    {
        var resultServices = _serviceRepository.GetAllAsync() ?? throw new NotFoundException(nameof(List<Service>));
        return await resultServices;
    }
    public Task DeleteServiceAsync(Service service)
    {
        return _serviceRepository.DeleteAsync(service);
    }
}