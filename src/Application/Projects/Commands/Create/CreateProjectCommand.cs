using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Projects.Commands.Create;
public record CreateProjectCommand : IRequest<CreateProjectPayload>
{
    public CreateProjectCommand()
    {
        GeographicalInfo = new GeographicalInfoDto(" ", " ", " ", " ", " ", " ");
        Contact = new ContactDto("", "", "", "", "", "", "");
    }
    public int? ClientId { get; init; }
    public virtual ClientDto? Client { get; set; }
    public virtual ContactDto? Contact { get; set; }
    public DateTime? CreatedDate { get; init; } = DateTime.Now;
    public DateTime? EndDate { get; init; }
    public int? TotalReceivedPackages { get; init; }
    public required string Sidemark { get; init; }
    public bool? DeclaredValueInsurace { get; init; }
    public decimal? Amount { get; init; }
    public string? InspectionNotes { get; init; }
    public bool? ReplaytoEmail { get; init; }
    public string? EmailSent { get; init; }
    public virtual GeographicalInfoDto GeographicalInfo { get; set; }
    public int CourierCompanyId { get; init; }
    public string? DriverName { get; init; }
    public string? ShippingNumber { get; init; }
    public string? ShipperOrigin { get; init; }
    public virtual ICollection<ProjectDetailDto>? ProjectDetail { get; init; }
}
public record CreateProjectPayload(ProjectDto Project);

public class CreateProjectCommandHandler(IProjectRepository projectRepository,
    IGeographicalInfoRepository geoRepository,
    IContactRepository contactRepository,
    IClientRepository clientRepository,
    IUnitOfWork unitOfWork,
    IStatusRepository statusRepository,
    IMapper mapper) : IRequestHandler<CreateProjectCommand, CreateProjectPayload>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IContactRepository _contactRepository = contactRepository;
    private readonly IGeographicalInfoRepository _geoRepository = geoRepository;
    private readonly IStatusRepository _statusRepository = statusRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateProjectPayload> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var entity = _mapper.Map<Project>(request);
        var geographEntity = _mapper.Map<GeographicalInfo>(request.GeographicalInfo);
        var contactEntity = _mapper.Map<Contact>(request.Contact);
        var clientEntity = _mapper.Map<Client>(request.Client);
        if (geographEntity.Id > 0)
        {
            var resultGeoInfo = _geoRepository.GetGeoInformationById(geographEntity.Id);
            if (resultGeoInfo is null)
            {
                var result = await _geoRepository.AddGeoInformationAsync(geographEntity);
                entity.GeographicalInfoId = result.Id;
                entity.GeographicalInfo = result;
            }
            else
            {
                resultGeoInfo = _mapper.Map<GeographicalInfo>(request.GeographicalInfo);
                var result = _geoRepository.UpdateGeoInformationAsync(resultGeoInfo);
                await _unitOfWork.Commit();
                entity.GeographicalInfoId = result.Id;
                entity.GeographicalInfo = null;
            }
        }
        else
        {
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
                entity.GeographicalInfo = null;
            }
        }

        if (contactEntity.Id > 0)
        {
            var resultContactInfo = _contactRepository.GetContactById(contactEntity.Id);
            if (resultContactInfo is null)
            {
                var resultContact = await _contactRepository.AddContactAsync(contactEntity);
                entity.Contact = resultContact;
                entity.ContactId = resultContact?.Id;
            }
            else
            {
                entity.ContactId = resultContactInfo.Id;
                entity.Contact = null;
            }
        }
        else
        {
            var resultContactInfo = _contactRepository.GetContactByData(contactEntity);
            if (resultContactInfo is null)
            {
                var resultContact = await _contactRepository.AddContactAsync(contactEntity);
                entity.Contact = resultContact;
                entity.ContactId = resultContact?.Id;
            }
            else
            {
                entity.ContactId = resultContactInfo.Id;
                entity.Contact = null;
            }
        }

        if (clientEntity.Id > 0)
        {
            var resultClientInfo = clientRepository.GetClientByIdAsync(clientEntity.Id);
            if (resultClientInfo is null)
            {
                var resultClient = await clientRepository.AddClientAsync(clientEntity);
                entity.Client = resultClient;
                entity.ClientId = resultClient!.Id;
            }
            else
            {
                entity.ClientId = resultClientInfo.Id;
                entity.Client = null;
            }
        }
        else
        {
            var resultClientInfo = clientRepository.GetClientByData(clientEntity);
            if (resultClientInfo is null)
            {
                var resultClient = await clientRepository.AddClientAsync(clientEntity);
                entity.Client = resultClient;
                entity.ClientId = resultClient!.Id;
            }
            else
            {
                entity.ClientId = resultClientInfo.Id;
                entity.Client = null;
            }
        }

        entity.StatusId = _statusRepository.GetStatus("Project", 1).Id;
        await _projectRepository.AddProjectAsync(entity);
        await _unitOfWork.Commit();
        return new CreateProjectPayload(_mapper.Map<ProjectDto>(entity));
    }
}