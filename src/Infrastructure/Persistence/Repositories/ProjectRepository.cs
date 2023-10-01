using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;

internal class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddProjectAsync(Project project, CancellationToken cancellationToken)
    {
        await _context.Projects.AddAsync(project, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Project> GetAllProjects()
    {
        return _context.Projects
            .AsQueryable()
            .AsNoTracking();
    }

    public async Task<Project?> FindProjectByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Projects.FirstOrDefaultAsync(
            t => t.Id == id, cancellationToken);
    }

    public async Task UpdateProjectAsync(Project project, CancellationToken cancellationToken)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync(cancellationToken);
    }
}