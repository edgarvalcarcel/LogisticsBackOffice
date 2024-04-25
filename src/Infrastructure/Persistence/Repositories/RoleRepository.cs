using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using ArgumentNullException = LogisticsBackOffice.Application.Common.Exceptions.ArgumentNullException;
namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
internal class RoleRepository(IRepositoryAsync<Role> roleRepository) : IRoleRepository
{
    private readonly IRepositoryAsync<Role> _roleRepository = roleRepository;
    public IQueryable<Role> GetAll => _roleRepository.Entities;

    public async Task<Role?> AddRoleAsync(Role role)
    {
        return await _roleRepository.AddAsync(role);
    }
    public Task DeleteRoleAsync(Role role)
    {
        return _roleRepository.DeleteAsync(role);
    }
    public async Task<List<Role?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await _roleRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }
    public async Task<List<Role>> GetRoleAllAsync()
    {
        var resultRoles = _roleRepository.GetAllAsync() ?? throw new NotFoundException(nameof(List<Role>));
        return await resultRoles;
    }
    public async Task<Role?> GetRoleByIdAsync(int id)
    {
        var resultRole = await _roleRepository.GetByIdAsync(id) ?? throw new NotFoundException(nameof(Role), id);
        return resultRole;
    }
    public Role UpdateRoleAsync(Role role)
    {
        ArgumentNullException.ThrowIfNull(role);
        return _roleRepository.Update(role);
    }
}
