using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Infrastructure.Identity;
using LogisticsBackOffice.Infrastructure.Persistence;
using LogisticsBackOffice.Infrastructure.Persistence.Interceptors;
using LogisticsBackOffice.Infrastructure.Persistence.Repositories;
using LogisticsBackOffice.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("Logistics.GraphQLDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            //    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //}, ServiceLifetime.Transient);
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        }
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        /* comment for inmigration */
        services.AddScoped<ApplicationDbContextInitializer>();
        /* Uncomment for inmigration */
        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));


        services.AddTransient<IClientContactRepository, ClientContactRepository>();
        services.AddTransient<IClientRepository, ClientRepository>();
        services.AddTransient<IContactRepository, ContactRepository>();
        services.AddTransient<IGeographicalInfoRepository, GeographicalInfoRepository>();
        services.AddTransient<IProjectDetailRepository, ProjectDetailRepository>();
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IServiceRepository, ServiceRepository>();
        services.AddTransient<IStatusRepository, StatusRepository>();
        services.AddTransient<IWorkerRepository, WorkerRepository>();
        services.AddTransient<IWorkOrderRepository, WorkOrderRepository>();
        services.AddTransient<IWorkOrderDetailRepository, WorkOrderDetailRepository>();

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        //services.Scan(scan => scan
        //    .FromCallingAssembly()
        //    .AddClasses(filter => filter.InNamespaceOf<ClientRepository>())
        //    .AsImplementedInterfaces());
        //services.Scan(scan => scan
        //   .FromCallingAssembly()
        //   .AddClasses(filter => filter.InNamespaceOf<ProjectRepository>())
        //   .AsImplementedInterfaces());
        //services.Scan(scan => scan
        //   .FromCallingAssembly()
        //   .AddClasses(filter => filter.InNamespaceOf<WorkOrderRepository>())
        //   .AsImplementedInterfaces());
        //services.Scan(scan => scan
        //   .FromCallingAssembly()
        //   .AddClasses(filter => filter.InNamespaceOf<ServiceRepository>())
        //   .AsImplementedInterfaces());
        return services;
    }
}