using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IServiceRepository
{
    Task AddServiceAsync(Service service, CancellationToken cancellationToken);
    IQueryable<Service> GetAllServices();
    Task<Service?> FindServiceByIdAsync(int id, CancellationToken cancellationToken);
    Task UpdateServiceAsync(Service service, CancellationToken cancellationToken);
}