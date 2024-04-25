using Duende.IdentityServer.EntityFramework.Options;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;
using LogisticsBackOffice.Infrastructure.Identity;
using LogisticsBackOffice.Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace LogisticsBackOffice.Infrastructure.Persistence;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    IOptions<OperationalStoreOptions> operationalStoreOptions,
    IMediator mediator,
    AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor,
    IDateTime dateTime) : ApiAuthorizationDbContext<ApplicationUser>(options, operationalStoreOptions), IApplicationDbContext
{
    private readonly IMediator _mediator = mediator;
    private readonly IDateTime _dateTime = dateTime;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;

    public bool HasChanges => ChangeTracker.HasChanges();
    public DbSet<Client> Client => Set<Client>();
    public DbSet<ClientContact> ClientContact => Set<ClientContact>();
    public DbSet<Contact> Contact => Set<Contact>();
    public DbSet<CountryRegion> CountryRegion => Set<CountryRegion>();
    public DbSet<GeographicalInfo> GeographicalInfo => Set<GeographicalInfo>();
    public DbSet<Worker> Worker => Set<Worker>();
    public DbSet<Project> Project => Set<Project>();
    public DbSet<ProjectDetail> ProjectDetail => Set<ProjectDetail>();
    public DbSet<Service> Service => Set<Service>();
    public DbSet<State> State => Set<State>();
    public DbSet<Status> Status => Set<Status>();
    public DbSet<WorkOrder> WorkOrder => Set<WorkOrder>();
    public DbSet<WorkOrderDetail> WorkOrderDetail => Set<WorkOrderDetail>();
    public DbSet<CourierCompany> CourierCompany => Set<CourierCompany>();
    public DbSet<Role> Role => Set<Role>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder, nameof(optionsBuilder));
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseIdEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _dateTime.Now;
                    entry.Entity.CreatedBy = string.Empty;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = _dateTime.Now;
                    entry.Entity.LastModifiedBy = string.Empty;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    break;
            }
        }
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
