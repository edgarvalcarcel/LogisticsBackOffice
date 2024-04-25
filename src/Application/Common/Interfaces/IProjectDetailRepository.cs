using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IProjectDetailRepository
{
    IQueryable<ProjectDetail> GetAll { get; }
    Task<ProjectDetail?> GetProjectDetailByIdAsync(int id);
    ProjectDetail? GetProjectDetail(int serviceId, int projectId);
    Task<List<ProjectDetail>> GetProjectDetailAllAsync();
    Task<List<ProjectDetail?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<ProjectDetail> AddProjectDetailAsync(ProjectDetail projectDetail);
    ProjectDetail UpdateProjectDetailAsync(ProjectDetail projectDetail);
    Task DeleteProjectDetailAsync(ProjectDetail projectDetail);
}
