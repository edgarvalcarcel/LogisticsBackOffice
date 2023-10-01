using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IProjectRepository
{
    Task AddProjectAsync(Project project, CancellationToken cancellationToken);
    IQueryable<Project> GetAllProjects();
    Task<Project?> FindProjectByIdAsync(int id, CancellationToken cancellationToken);
    Task UpdateProjectAsync(Project project, CancellationToken cancellationToken);
}