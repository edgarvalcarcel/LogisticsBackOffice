using HotChocolate.Types.Pagination;
using LogisticsBackOffice.GraphQL.Filters;
using LogisticsBackOffice.Infrastructure.Persistence;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddGraphQLServices();
builder.Services
    .AddGraphQLServer()
    .AddInMemorySubscriptions()
    .AddTypes()
    .RegisterDbContext<ApplicationDbContext>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddErrorFilter<ValidationFilter>()
    .SetPagingOptions(new PagingOptions()
    {
        MaxPageSize = 50,
        DefaultPageSize = 20,
        IncludeTotalCount = true
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    // Initialise and seed database
    using var scope = app.Services.CreateScope();
    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    if (builder.Configuration.GetValue<bool>("SeedingDatabase"))
    {
        await initializer.InitialiseAsync();
        await initializer.SeedAsync();
    }
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHealthChecks("/health");
app.UseHttpsRedirection();

app.UseRouting();

app.UseWebSockets();

app.MapGraphQL();

app.Run();
public partial class Program { }