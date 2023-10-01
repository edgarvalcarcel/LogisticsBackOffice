using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IQueryable<Project>>
{
    private readonly IProjectRepository _repository;
    public GetProjectsQueryHandler(IProjectRepository repository)
    {
        _repository = repository;
    }
    public async Task<IQueryable<Project>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        return  _repository.GetAllProjects()
            .OrderBy(t => t.CreationDate);
    }
}
