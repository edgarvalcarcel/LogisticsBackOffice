using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    bool HasChanges { get; }
    DbSet<Client> Client { get; }
    DbSet<ClientContact> ClientContact { get; }
    DbSet<Contact> Contact { get; }
    DbSet<CountryRegion> CountryRegion { get; }
    DbSet<CourierCompany> CourierCompany { get; }
    DbSet<GeographicalInfo> GeographicalInfo { get; }
    DbSet<Project> Project { get; }
    DbSet<ProjectDetail> ProjectDetail { get; }
    DbSet<Service> Service { get; }
    DbSet<State> State { get; }
    DbSet<Status> Status { get; }
    DbSet<Worker> Worker { get; }
    DbSet<WorkOrder> WorkOrder { get; }
    DbSet<WorkOrderDetail> WorkOrderDetail { get; }
    DbSet<Role> Role { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}