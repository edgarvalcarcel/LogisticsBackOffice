using System.Diagnostics;
using LogisticsBackOffice.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LogisticsBackOffice.Application.Common.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse>(
    ILogger<TRequest> logger,
    ICurrentUserService currentUserService,
    IIdentityService identityService) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer = new();

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();
#pragma warning disable CA1062 // Validate arguments of public methods
        var response = await next();
#pragma warning restore CA1062 // Validate arguments of public methods
        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;
        //if (elapsedMilliseconds > 500)
        //{}
        var requestName = typeof(TRequest).Name;
        var userId = currentUserService.UserId ?? string.Empty;
        var userName = string.Empty;
        if (!string.IsNullOrEmpty(userId))
        {
            userName = await identityService.GetUserNameAsync(userId);
        }
        logger.LogWarning("BackOffice Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
            requestName, elapsedMilliseconds, userId, userName, request);
        return response;
    }
}
