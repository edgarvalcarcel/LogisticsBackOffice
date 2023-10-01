using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Services.Commands.AddService;

public class AddServicePayload : ServicePayloadBase
{
    public AddServicePayload(Service service)
        : base(service)
    {
    }

    public AddServicePayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}