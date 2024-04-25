using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;
namespace LogisticsBackOffice.Application.Roles.Queries.GetRoles;
public record GetRolesQuery() : IRequest<IList<RoleDto>>;
public record GetRolesPayloadResponse(IList<RoleDto?> Clients);
public class GetRolesQueryHandler(IRoleRepository repository, IMapper mapper) : IRequestHandler<GetRolesQuery, IList<RoleDto>>
{
    public async Task<IList<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetRoleAllAsync();
        return entities.Select(mapper.Map<RoleDto>).ToList();
    }
}
