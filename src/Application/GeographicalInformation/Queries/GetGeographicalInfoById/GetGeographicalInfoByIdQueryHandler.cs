using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.GeographicalInformation.Queries.GetGeographicalInfoById;

public class GetGeographicalInfoByIdQueryHandler : IRequestHandler<GetGeographicalInfoByIdQuery, GeographicalInfo>
{
    private readonly IGeographicalInfoByIdDataLoader _dataLoader;
    public GetGeographicalInfoByIdQueryHandler(IGeographicalInfoByIdDataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }
    public async Task<GeographicalInfo> Handle(GetGeographicalInfoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dataLoader.LoadAsync(request.Id, cancellationToken);
    }
}
