using LogisticsBackOffice.Domain.Entities;
namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IRoleRepository
{
    IQueryable<Role> GetAll { get; }
    Task<Role?> GetRoleByIdAsync(int id);
    Task<List<Role>> GetRoleAllAsync();
    Task<List<Role?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<Role?> AddRoleAsync(Role role);
    Role UpdateRoleAsync(Role role);
    Task DeleteRoleAsync(Role role);
}
