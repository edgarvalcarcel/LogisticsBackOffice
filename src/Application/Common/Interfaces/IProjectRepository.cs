using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IProjectRepository
{
    IQueryable<Project> GetAll { get; }
    Task<Project?> GetProjectByIdAsync(int id);
    Task<List<Project>> GetProjectAllAsync();
    Task<List<Project?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<Project> AddProjectAsync(Project project);
    Project UpdateProjectAsync(Project project);
    Task DeleteProjectAsync(Project project);
}
