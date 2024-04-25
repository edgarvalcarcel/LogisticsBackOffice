using LogisticsBackOffice.Application.Common.Interfaces;

namespace LogisticsBackOffice.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
