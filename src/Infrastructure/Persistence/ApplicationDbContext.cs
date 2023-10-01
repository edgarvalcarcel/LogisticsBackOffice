using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region project
        modelBuilder.Entity<Project>()
           .HasIndex(pr => new { pr.Id }).IsUnique();

        modelBuilder.Entity<Project>()
            .HasOne(pr => pr.GeographicalInfo)
            .WithOne(gi => gi.Project);

             modelBuilder.Entity<Project>()
            .HasOne(pr => pr.Client)
            .WithOne(gi => gi.Project);

        modelBuilder.Entity<Project>()
            .HasOne(pr => pr.Contact)
            .WithOne(gi => gi.Project);

        modelBuilder.Entity<Project>()
            .HasOne(pr => pr.OperatorReceiving)
            .WithOne(gi => gi.Project);

        modelBuilder.Entity<Project>()
            .HasMany(pr => pr.ProjectDetails)
            .WithOne(pd => pd.Project)
            .HasForeignKey(pd => pd.ProjectId);
        #endregion project

        #region project detail
        modelBuilder.Entity<ProjectDetail>()
            .HasIndex(pd => new { pd.Id}).IsUnique();

        modelBuilder.Entity<ProjectDetail>()
            .HasIndex(pd => new { pd.ProjectId,pd.ServiceId }).IsUnique();

        modelBuilder.Entity<ProjectDetail>()
            .HasOne(pd => pd.Project)
            .WithMany(pr => pr.ProjectDetails);

        modelBuilder.Entity<ProjectDetail>()
            .HasMany(pd => pd.ProjectDetailServices)
            .WithOne(pds => pds.ProjectDetail)
            .HasForeignKey(pds => pds.ProjectDetailId);
        #endregion project detail

        #region project detail service
        modelBuilder.Entity<ProjectDetailService>()
           .HasIndex(pds => new { pds.Id }).IsUnique();

        modelBuilder.Entity<ProjectDetailService>()
            .HasIndex(pds => new { pds.ProjectDetailId, pds.ServiceId,pds.OperatorId }).IsUnique();

        modelBuilder.Entity<ProjectDetailService>()
            .HasOne(pds => pds.ProjectDetail)
            .WithMany(pd => pd.ProjectDetailServices);
        #endregion project detail service


        modelBuilder
            .Entity<Client>()
            .HasIndex(a => a.Email)
            .IsUnique();

        modelBuilder
           .Entity<Contact>()
           .HasIndex(c => c.Email)
           .IsUnique();

        modelBuilder
           .Entity<Operator>()
           .HasIndex(o => o.Email)
           .IsUnique();

        modelBuilder
            .Entity<ClientContact>()
            .HasKey(cc => new { cc.ClientId, cc.ContactId });
    }

    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<ClientContact> ClientContacts { get; set; } = default!;
    public DbSet<Contact> Contacts { get; set; } = default!;
    public DbSet<CountryRegion> CountryRegions { get; set; } = default!;
    public DbSet<GeographicalInfo> GeographicalInfo { get; set; } = default!;
    public DbSet<Operator> Operators { get; set; } = default!;
    public DbSet<Project> Projects { get; set; } = default!;
    public DbSet<ProjectDetail> ProjectDetails { get; set; } = default!;
    public DbSet<ProjectDetailService> ProjectDetailServices { get; set; } = default!;
    public DbSet<ProjectGeographicalInfo> ProjectGeographicalInfo { get; set; } = default!;
    public DbSet<Service> Services { get; set; } = default!;
    public DbSet<State> State { get; set; } = default!;
    public DbSet<WorkOrder> WorkOrders { get; set; } = default!;
}