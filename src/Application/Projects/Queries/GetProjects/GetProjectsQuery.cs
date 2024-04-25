using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.Projects.Queries.GetProjects;
public record GetProjectsQuery() : IRequest<IList<ProjectDto>>;
public record GetProjectsPayloadResponse(IList<ProjectDto?> Clients);
public class GetProjectsQueryHandler(IProjectRepository repository, IMapper mapper) : IRequestHandler<GetProjectsQuery, IList<ProjectDto>>
{
    public async Task<IList<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetProjectAllAsync();
        return entities.Select(mapper.Map<ProjectDto>).ToList();
    }
}