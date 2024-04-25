using MediatR;
using Microsoft.Extensions.Logging;

namespace LogisticsBackOffice.Application.Common.Behaviours;
public class ArgumentNullBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (ArgumentNullException ex)
        {
            var requestName = typeof(TRequest).Name;

            logger.LogError(ex, "Request: Null Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
    }
}
//  if ( )
//  {
//      throw new UnauthorizedAccessException();
//  }
//  if (!authorized)
//  {
//     throw new ForbiddenAccessException();
//  }