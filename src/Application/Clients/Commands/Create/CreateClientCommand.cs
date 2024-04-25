using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Commands.Create;
public record CreateClientCommand : IRequest<CreateClientPayload>
{
    public CreateClientCommand()
    {
        GeographicalInfo = new GeographicalInfoDto(" ", " ", " ", " ", " ", " ");
    }
    public string? Title { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? FullName { get; set; }
    public string? Suffix { get; init; }
    public string? Email { get; init; }
    public string? Cellphone { get; init; }
    public string? AdditionalInfo { get; init; }
    public required GeographicalInfoDto GeographicalInfo { get; set; }
    public IList<ClientContactDto> ClientContact { get; init; } = [];
}
public record CreateClientPayload(ClientDto Client);

public class CreateClientCommandHandler(IClientRepository clientRepository,
     IGeographicalInfoRepository geoRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateClientCommand, CreateClientPayload>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IGeographicalInfoRepository _geoRepository = geoRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateClientPayload> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);

        var entity = _mapper.Map<Client>(request);
        var geographEntity = _mapper.Map<GeographicalInfo>(request.GeographicalInfo);

        if (geographEntity.Id > 0)
        {
            entity.GeographicalInfo = null;
            var resultGeoInfo = _geoRepository.GetGeoInformationById(geographEntity.Id);
            if (resultGeoInfo is null)
            {
                var result = await _geoRepository.AddGeoInformationAsync(geographEntity);
                entity.GeographicalInfo = result;
                entity.GeographicalInfoId = result.Id;
            }
            else
            {
                resultGeoInfo = _mapper.Map<GeographicalInfo>(request.GeographicalInfo);
                var result = _geoRepository.UpdateGeoInformationAsync(resultGeoInfo);
                await _unitOfWork.Commit();
                entity.GeographicalInfoId = result.Id;
            }
        }
        else
        {
            entity.GeographicalInfo = null;
            var resultGeoInfo = _geoRepository.GetGeoInformationByData(geographEntity);
            if (resultGeoInfo is null)
            {
                var result = await _geoRepository.AddGeoInformationAsync(geographEntity);
                entity.GeographicalInfoId = result.Id;
                entity.GeographicalInfo = result;
            }
            else
            {
                entity.GeographicalInfoId = resultGeoInfo.Id;
            }
        }
        await _clientRepository.AddClientAsync(entity);
        await _unitOfWork.Commit();
        return new CreateClientPayload(_mapper.Map<ClientDto>(entity));
    }
}