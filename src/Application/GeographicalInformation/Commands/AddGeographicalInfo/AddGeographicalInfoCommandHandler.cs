using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.GeographicalInformation.Commands.AddGeographicalInfo;

public class AddGeographicalInfoCommandHandler : IRequestHandler<AddGeographicalInfoCommand, GeographicalInfo>
{
    private readonly IGeographicalInfoRepository _repository;

    public AddGeographicalInfoCommandHandler(IGeographicalInfoRepository repository)
    {
        _repository = repository;
    }

    public async Task<GeographicalInfo> Handle(AddGeographicalInfoCommand request, CancellationToken cancellationToken)
    {
        var geographicalInfo = new GeographicalInfo
        {
            AddressLine1 = request.AddressLine1,
            AddressLine2 = request.AddressLine2,
            City = request.City,
            StateId = request.StateId,
            PostalCode = request.PostalCode,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            LocationName = request.LocationName,
            PhoneNumber = request.PhoneNumber
        };

        await _repository.AddGeographicalInfoAsync(geographicalInfo, cancellationToken);
        return geographicalInfo;
    }
}
