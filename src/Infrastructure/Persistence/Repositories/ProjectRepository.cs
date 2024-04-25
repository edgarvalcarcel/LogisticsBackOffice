using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class ProjectRepository(IRepositoryAsync<Project> projectRepository,
    ApplicationDbContext dbContext) : IProjectRepository
{
    private readonly IRepositoryAsync<Project> _projectRepository = projectRepository;
    private readonly ApplicationDbContext _dbContext = dbContext;
    public IQueryable<Project> GetAll => _projectRepository.Entities;
    public async Task<Project> AddProjectAsync(Project project)
    {
        return await _projectRepository.AddAsync(project);
    }
    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        var resultProject = await _dbContext.Project
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Include(p => p.Client)
            .Include(p => p.Contact)
            .Include(p => p.GeographicalInfo)
            .Include(p => p.ProjectDetail)
            .OrderBy(p => p.Id)
            .FirstOrDefaultAsync();
        return resultProject;
    }
    public async Task<List<Project?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await _projectRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }
    public Project UpdateProjectAsync(Project project)
    {
        return _projectRepository.Update(project);
    }
    public async Task<List<Project>> GetProjectAllAsync()
    {
        var resultProjects = new List<Project>();
        resultProjects = await _dbContext.Project
            .Include(p => p.Client)
            .Include(p => p.Contact)
            .Include(p => p.GeographicalInfo).ThenInclude(g => g!.State)
            .Include(p => p.ProjectDetail).ThenInclude(pd => pd.Service)
            .AsNoTracking()
            .OrderBy(p => p.Id).ToListAsync();
        return resultProjects;
    }
    public Task DeleteProjectAsync(Project project)
    {
        return _projectRepository.DeleteAsync(project);
    }
}