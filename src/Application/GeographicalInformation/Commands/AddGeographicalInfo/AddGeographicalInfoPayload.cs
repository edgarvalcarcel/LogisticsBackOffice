using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.GeographicalInformation.Commands.AddGeographicalInfo;

public class AddGeographicalInfoPayload : GeographicalInfoPayloadBase
{
    public AddGeographicalInfoPayload(GeographicalInfo geographicalInfo)
        : base(geographicalInfo)
    {
    }

    public AddGeographicalInfoPayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
