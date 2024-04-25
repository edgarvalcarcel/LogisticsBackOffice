using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
namespace LogisticsBackOffice.Application.Projects.Commands.Modify;
public record ModifyProjectCommand : IRequest<ModifyProjectPayload>
{
    public ModifyProjectCommand()
    {
        GeographicalInfo = new GeographicalInfoDto(" ", " ", " ", " ", " ", " ");
        Contact = new ContactDto("", "", "", "", "", "", "");
    }
    public int Id { get; init; }
    public int ClientId { get; init; }
    public virtual ClientDto? Client { get; set; }
    public int ContactId { get; set; }
    public virtual ContactDto? Contact { get; set; }
    public DateTime? EndDate { get; init; } = DateTime.MinValue;
    public int? TotalReceivedPackages { get; init; }
    public required string Sidemark { get; init; }
    public bool? DeclaredValueInsurace { get; init; }
    public decimal? Amount { get; init; }
    public string? InspectionNotes { get; init; }
    public bool? ReplaytoEmail { get; init; }
    public string? EmailSent { get; init; }
    public int GeographicalInfoId { get; set; }
    public virtual GeographicalInfoDto GeographicalInfo { get; set; }
    public int CourierCompanyId { get; init; }
    public string? DriverName { get; init; }
    public string? ShippingNumber { get; init; }
    public string? ShipperOrigin { get; init; }
    public virtual ICollection<ProjectDetailDto>? ProjectDetail { get; init; }
    public int? StatusId { get; set; }
}
public record ModifyProjectPayload(ProjectDto Project);
public class ModifyProjectCommandHandler(IProjectRepository projectRepository,
    IGeographicalInfoRepository geoRepository,
    IContactRepository contactRepository,
    IClientRepository clientRepository,
    IProjectDetailRepository projectDetailRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<ModifyProjectCommand, ModifyProjectPayload>
{
    public async Task<ModifyProjectPayload> Handle(ModifyProjectCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entity = await projectRepository.GetProjectByIdAsync(request.Id);
        if (entity is null) return new ModifyProjectPayload(mapper.Map<ProjectDto>(entity));

        ArgumentNullException.ThrowIfNull(request.ProjectDetail);
        if (entity.ProjectDetail.Count >= 0)
        {
            foreach (var item in entity.ProjectDetail)
            {
                await projectDetailRepository.DeleteProjectDetailAsync(item);
            }
            await unitOfWork.Commit();
            entity.ProjectDetail = [];
        }
        entity = mapper.Map<Project>(request);
        if (request.GeographicalInfo is not null)
        {
            entity.GeographicalInfo = mapper.Map<GeographicalInfo>(request.GeographicalInfo);
        }
        if (request.Contact is not null)
        {
            entity.Contact = mapper.Map<Contact>(request.Contact);
        }
        if (request.GeographicalInfo is not null)
        {
            var geographEntity = mapper.Map<GeographicalInfo>(request.GeographicalInfo);
            if (geographEntity.Id > 0)
            {
                var resultGeoInfo = geoRepository.GetGeoInformationById(geographEntity.Id);
                if (resultGeoInfo is null)
                {
                    var result = await geoRepository.AddGeoInformationAsync(geographEntity);
                    entity.GeographicalInfo = result;
                    entity.GeographicalInfoId = result.Id;
                }
            }
            else
            {
                var resultGeoInfo = geoRepository.GetGeoInformationByData(geographEntity);
                if (resultGeoInfo is null)
                {
                    var result = await geoRepository.AddGeoInformationAsync(geographEntity);
                    entity.GeographicalInfoId = result.Id;
                    entity.GeographicalInfo = result;
                }
                else
                {
                    entity.GeographicalInfoId = resultGeoInfo.Id;
                    entity.GeographicalInfo = null;
                }
            }
        }
        if (request.Contact is not null)
        {
            var contactEntity = mapper.Map<Contact>(request.Contact);
            if (contactEntity.Id > 0)
            {
                var resultContact = contactRepository.GetContactById(contactEntity.Id);
                if (resultContact is null)
                {
                    var result = await contactRepository.AddContactAsync(contactEntity);
                    await unitOfWork.Commit();
                    entity.ContactId = result.Id;
                }
            }
            else
            {
                var resultContactInfo = contactRepository.GetContactByData(contactEntity);
                if (resultContactInfo is null)
                {
                    var result = await contactRepository.AddContactAsync(contactEntity);
                    await unitOfWork.Commit();
                    entity.ContactId = result.Id;
                }
                else
                {
                    entity.ContactId = resultContactInfo.Id;
                    entity.Contact = null;
                }
            }
        }
        if (request.Client is not null)
        {
            var clientEntity = mapper.Map<Client>(request.Client);
            if (clientEntity.Id > 0)
            {
                var resultClient = clientRepository.GetClientByIdAsync(clientEntity.Id);
                if (resultClient is null)
                {
                    var result = await clientRepository.AddClientAsync(clientEntity);
                    await unitOfWork.Commit();
                    entity.ClientId = result!.Id;
                }
            }
            else
            {
                var resultClientInfo = clientRepository.GetClientByData(clientEntity);
                if (resultClientInfo is null)
                {
                    var result = await clientRepository.AddClientAsync(clientEntity);
                    await unitOfWork.Commit();
                    entity.ClientId = result!.Id;
                }
                else
                {
                    entity.ClientId = resultClientInfo.Id;
                    entity.Client = null;
                }
            }
        }

        ArgumentNullException.ThrowIfNull(request.ProjectDetail);
        if (request.ProjectDetail != null && request.ProjectDetail.Any())
        {
            entity.ProjectDetail = request.ProjectDetail != null
            ? request.ProjectDetail.Select(item => mapper.Map<ProjectDetail>(item)).ToList()
            : [];
            foreach (var item in entity.ProjectDetail)
            {
                item.ProjectId = entity.Id;
                await projectDetailRepository.AddProjectDetailAsync(item);
            }
        }
        projectRepository.UpdateProjectAsync(entity);
        await unitOfWork.Commit();
        return new ModifyProjectPayload(mapper.Map<ProjectDto>(entity));
    }
}
