using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class ProjectDetailRepository(IRepositoryAsync<ProjectDetail> projectDetailRepository,
    ApplicationDbContext dbContext) : IProjectDetailRepository
{
    private readonly IRepositoryAsync<ProjectDetail> _projectDetailRepository = projectDetailRepository;
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IQueryable<ProjectDetail> GetAll => _projectDetailRepository.Entities;
    public async Task<ProjectDetail> AddProjectDetailAsync(ProjectDetail projectDetail)
    {
        return await _projectDetailRepository.AddAsync(projectDetail);
    }
    public Task DeleteProjectDetailAsync(ProjectDetail projectDetail)
    {
        return _projectDetailRepository.DeleteAsync(projectDetail);
    }
    public async Task<List<ProjectDetail?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await _projectDetailRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }
    public ProjectDetail? GetProjectDetail(int serviceId, int projectId)
    {
        if (serviceId != 0 && projectId != 0)
        {
            var resultProjectDetail = _dbContext.ProjectDetail
             .AsNoTracking()
            .Where(p => p.ProjectId == projectId && p.ServiceId == serviceId)
            .Include(p => p.Service)
            .OrderBy(p => p.Id).FirstOrDefault();
            return resultProjectDetail;
        }
        return null;
    }
    public async Task<ProjectDetail?> GetProjectDetailByIdAsync(int id)
    {
        var resultProjectDetail = await _dbContext.ProjectDetail
            .Include(p => p.Service)
            .AsNoTracking()
            .OrderBy(p => p.Id).FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(ProjectDetail), id);
        return resultProjectDetail;
    }
    public async Task<List<ProjectDetail>> GetProjectDetailAllAsync()
    {
        var resultProjectDetails = new List<ProjectDetail>();
        resultProjectDetails = await _dbContext.ProjectDetail
            .Include(p => p.Service)
            .AsNoTracking()
            .OrderBy(p => p.Id).ToListAsync() ?? throw new NotFoundException(nameof(List<ProjectDetail>));
        return resultProjectDetails;
    }
    public ProjectDetail UpdateProjectDetailAsync(ProjectDetail projectDetail)
    {
        return _projectDetailRepository.Update(projectDetail);
    }
}
