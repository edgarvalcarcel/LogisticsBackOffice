using HotChocolate.Execution.Configuration;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Infrastructure.Persistence;
using LogisticsBackOffice.Infrastructure.Persistence.DataLoaders;
using LogisticsBackOffice.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticsBackOffice.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
       IConfiguration configuration)
    {
        var isInMemoryDatabase = configuration.GetValue<bool>("UseInMemoryDatabase");

        if (isInMemoryDatabase)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(_ =>
                _.UseInMemoryDatabase("LogisticsDb"));
        }
        else
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(_ =>
                _.UseSqlServer(
                    configuration.GetConnectionString("SqlDbConnection"),
                    a =>
                        a.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddTransient<IClientRepository>(_ =>
                new ClientRepository(
                    _.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext()))
            .AddTransient<IContactRepository>(_ =>
                new ContactRepository(
                    _.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext()))
            .AddTransient<IGeographicalInfoRepository>(_ =>
                new GeographicalInfoRepository(
                    _.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext()))
            .AddTransient<IOperatorRepository>(_ =>
                new OperatorRepository(
                    _.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext()))
            .AddTransient<IProjectRepository>(_ =>
                new ProjectRepository(
                    _.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext()))
            .AddTransient<IServiceRepository>(_ =>
                new ServiceRepository(
                    _.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext()))
            .AddTransient<IStateRepository>(_ =>
                new StateRepository(
                    _.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext()))
            .AddTransient<IWorkOrderRepository>(_ =>
                new WorkOrderRepository(
                    _.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext())); 

        return services;
    }

    public static IRequestExecutorBuilder AddDataLoaders(this IRequestExecutorBuilder builder)
    {
        builder.AddDataLoader<IClientByIdDataLoader, ClientByIdDataLoader>()
            .AddDataLoader<IContactByIdDataLoader, ContactByIdDataLoader>()
            .AddDataLoader<IGeographicalInfoByIdDataLoader, GeographicalInfoByIdDataLoader>()
            .AddDataLoader<IOperatorByIdDataLoader, OperatorByIdDataLoader>()
            .AddDataLoader<IProjectByIdDataLoader, ProjectByIdDataLoader>()
            .AddDataLoader<IServiceByIdDataLoader, ServiceByIdDataLoader>()
            .AddDataLoader<IWorkOrderByIdDataLoader, WorkOrderByIdDataLoader>();
        return builder;
    }
}