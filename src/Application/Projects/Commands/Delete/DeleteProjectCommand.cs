using AutoMapper;
using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using LogisticsBackOffice.Domain.Events.ProjectEvents;
using MediatR;
using ArgumentNullException = LogisticsBackOffice.Application.Common.Exceptions.ArgumentNullException;
namespace LogisticsBackOffice.Application.Projects.Commands.Delete;
public record DeleteProjectCommand(int Id) : IRequest<DeleteProjectPayload>;
public record DeleteProjectPayload(ProjectDto Project);
public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, DeleteProjectPayload>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IGeographicalInfoRepository _geoRepository;
    private readonly IProjectDetailRepository _projectDetailRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IContactRepository _contactRepository;
    public DeleteProjectCommandHandler(IProjectRepository projectRepository,
     IGeographicalInfoRepository geoRepository,
    IUnitOfWork unitOfWork,
    IProjectDetailRepository projectDetailRepository,
    IContactRepository contactRepository,
    IMapper mapper)
    {
        _projectRepository = projectRepository;
        _geoRepository = geoRepository;
        _projectDetailRepository = projectDetailRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _contactRepository = contactRepository;
    }
    public async Task<DeleteProjectPayload> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var entity = await _projectRepository.GetProjectByIdAsync(request.Id) ?? throw new NotFoundException(nameof(ProjectDto), request.Id);
        if (entity.GeographicalInfoId != null)
        {
            var entityGeo = _geoRepository.GetGeoInformationById((int)entity.GeographicalInfoId) ?? throw new NotFoundException(nameof(GeographicalInfoDto), request.Id);
            await _geoRepository.DeleteGeoInformationAsync(entityGeo);
        }
        ArgumentNullException.ThrowIfNull(entity.ProjectDetail);
        if (entity.ProjectDetail.Count >= 0)
        {
            foreach (var item in entity.ProjectDetail)
            {
                await _projectDetailRepository.DeleteProjectDetailAsync(item);
            }
            await _unitOfWork.Commit();
            entity.ProjectDetail = [];
        }
        await _contactRepository.DeleteContactAsync(_mapper.Map<Contact>(entity.Contact));
        await _geoRepository.DeleteGeoInformationAsync(_mapper.Map<GeographicalInfo>(entity.GeographicalInfo));
        await _projectRepository.DeleteProjectAsync(entity);

        entity.AddDomainEvent(new ProjectDeletedEvent(entity));
        await _unitOfWork.Commit();
        return new DeleteProjectPayload(_mapper.Map<ProjectDto>(entity));
    }
}
