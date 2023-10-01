using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Projects.Queries.GetProjectById;
internal class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
{
    private readonly IProjectByIdDataLoader _dataLoader;
    public GetProjectByIdQueryHandler(IProjectByIdDataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }
    public async Task<Project> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dataLoader.LoadAsync(request.Id, cancellationToken);
    }
}
