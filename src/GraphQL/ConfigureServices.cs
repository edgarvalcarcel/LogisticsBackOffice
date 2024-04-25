using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Infrastructure.Persistence;
using LogisticsBackOffice.WebUI.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddGraphQLServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();


        return services;
    }
}
