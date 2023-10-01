using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Services;
public class ServicePayloadBase : Payload
{
    protected ServicePayloadBase(Service service)
    {
        Service = service;
    }
    protected ServicePayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
    public Service? Service;
}

