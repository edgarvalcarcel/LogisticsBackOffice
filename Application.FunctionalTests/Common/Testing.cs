using LogisticsBackOffice.Application.FunctionalTests.Common;
using LogisticsBackOffice.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;

namespace LogisticsBackOffice.Application.FunctionalTests;

[SetUpFixture]
public partial class Testing
{
    //private static WebApplicationFactory<Program> _factory = null!;
    private static IConfiguration s_configuration = null!;
    private static CustomWebApplicationFactory _factory = null!;
    private static IServiceScopeFactory s_scopeFactory = null!;
    private static Respawner s_checkpoint = null!;

    [OneTimeSetUp]
    public static void RunBeforeAnyTests()
    {
        _factory = new CustomWebApplicationFactory();
        s_scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        s_configuration = _factory.Services.GetRequiredService<IConfiguration>();

        s_checkpoint = Respawner.CreateAsync(s_configuration.GetConnectionString("QA_DefaultConnection")!, new RespawnerOptions
        {
            TablesToIgnore = ["__EFMigrationsHistory"]
        }).GetAwaiter().GetResult();
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        if (s_scopeFactory == null)
        {
            RunBeforeAnyTests();
        }

        using var scope = s_scopeFactory?.CreateScope();
        var mediator = scope?.ServiceProvider.GetRequiredService<ISender>();
        return await mediator!.Send(request);
    }

    public static async Task SendAsync(IBaseRequest request)
    {
        using var scope = s_scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();
        await mediator.Send(request);
    }
    public static Task ResetState()
    {
        try
        {
            ArgumentNullException.ThrowIfNull(s_checkpoint);
            //await s_checkpoint.ResetAsync(s_configuration.GetConnectionString("QA_DefaultConnection")!);
        }
        catch (Exception)
        {
        }

        return Task.CompletedTask;
    }

    public static async Task<TEntity?> FindAsync<TEntity>(params object[] keyValues)
        where TEntity : class
    {
        if (s_scopeFactory == null)
        {
            RunBeforeAnyTests();
        }
        using var scope = s_scopeFactory?.CreateScope();
        var context = scope?.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var entity = await context!.FindAsync<TEntity>(keyValues);
        return entity;
    }

    public static async Task AddAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        using var scope = s_scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Add(entity);
        await context.SaveChangesAsync();
    }

    public static async Task<int> CountAsync<TEntity>() where TEntity : class
    {
        using var scope = s_scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        return await context.Set<TEntity>().CountAsync();
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
    }
}
