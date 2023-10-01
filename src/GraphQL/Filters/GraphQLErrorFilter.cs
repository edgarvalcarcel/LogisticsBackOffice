using System;
namespace LogisticsBackOffice.APIGraphQL.Filters
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            var message = error.Exception == null ? error.Message : error.Exception.Message;

            return error.RemoveExtension("stackTrace")
                        .RemoveExtension("message")
                        .RemoveLocations()
                        .WithMessage(message);
        }
    }
}
