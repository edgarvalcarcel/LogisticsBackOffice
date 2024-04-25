using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;
namespace LogisticsBackOffice.Application.Projects.Queries.GetProjectById;
public record GetProjectByIdQuery(int Id) : IRequest<ProjectDto?>;
public class GetProjectByIdQueryHandler(IProjectRepository repository, IMapper mapper) : IRequestHandler<GetProjectByIdQuery, ProjectDto?>
{
    public async Task<ProjectDto?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var client = await repository.GetProjectByIdAsync(request.Id);
        return mapper.Map<ProjectDto>(client);
    }
}
