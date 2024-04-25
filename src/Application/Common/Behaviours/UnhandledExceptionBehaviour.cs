using MediatR;
using Microsoft.Extensions.Logging;

namespace LogisticsBackOffice.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger = logger;
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(next, nameof(next));
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            var innerException = ex.InnerException;
            _logger.LogError(ex, "BackOffice Request: Unhandled Exception for Request {Name} {@innerException} {@Request}", requestName, innerException, request);
            throw;
        }
    }
}
