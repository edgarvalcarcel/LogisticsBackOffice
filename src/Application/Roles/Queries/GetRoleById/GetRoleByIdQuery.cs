using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.Roles.Queries.GetRoleById;
public record GetRoleByIdQuery(int Id) : IRequest<RoleDto?>;
public class GetRoleByIdQueryHandler(IRoleRepository repository, IMapper mapper) : IRequestHandler<GetRoleByIdQuery, RoleDto?>
{
    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var role = await repository.GetRoleByIdAsync(request.Id);
        return mapper.Map<RoleDto>(role);
    }
}