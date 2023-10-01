using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.GeographicalInformation;

public class GeographicalInfoPayloadBase : Payload
{
    public GeographicalInfoPayloadBase(GeographicalInfo geographicalInfo)
    {
        GeographicalInfo = geographicalInfo;
    }
    public GeographicalInfo? GeographicalInfo { get; }

    protected GeographicalInfoPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
}
