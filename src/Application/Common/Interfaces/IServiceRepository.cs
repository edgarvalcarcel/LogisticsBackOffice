using LogisticsBackOffice.Domain.Entities;
namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IServiceRepository
{
    IQueryable<Service> GetAll { get; }
    Task<Service?> GetServiceByIdAsync(int id);
    Task<List<Service>> GetServiceAllAsync();
    Task<List<Service?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<Service?> AddServiceAsync(Service service);
    Service UpdateServiceAsync(Service service);
    Task DeleteServiceAsync(Service service);
}
