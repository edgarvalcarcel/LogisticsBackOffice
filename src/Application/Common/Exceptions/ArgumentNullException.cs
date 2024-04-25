using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace LogisticsBackOffice.Application.Common.Exceptions;
public class ArgumentNullException : Exception
{
    public ArgumentNullException() : base() { }

    public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
        {
            ThrowIfNull(paramName);
        }
    }
    public ArgumentNullException(string message) : base(message)
    {
    }
    public ArgumentNullException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
