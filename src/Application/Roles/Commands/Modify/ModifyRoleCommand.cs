using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
namespace LogisticsBackOffice.Application.Roles.Commands.Modify;
public record ModifyRoleCommand : IRequest<ModifyRolePayload>
{
    public int Id { get; init; }
    public string? Name { get; init; }
}
public record ModifyRolePayload(RoleDto? Role);
public class ModifyRoleCommandHandler(IRoleRepository roleRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<ModifyRoleCommand, ModifyRolePayload>
{
    public async Task<ModifyRolePayload> Handle(ModifyRoleCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entityRoleExist = await roleRepository.GetRoleByIdAsync(request.Id);
        if (entityRoleExist is null) return new ModifyRolePayload(mapper.Map<RoleDto>(entityRoleExist));

        entityRoleExist = mapper.Map<Role>(request);

        roleRepository.UpdateRoleAsync(entityRoleExist);
        await unitOfWork.Commit();

        return new ModifyRolePayload(mapper.Map<RoleDto>(entityRoleExist));
    }
}