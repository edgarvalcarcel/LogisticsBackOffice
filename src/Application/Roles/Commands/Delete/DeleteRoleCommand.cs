using AutoMapper;
using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;
namespace LogisticsBackOffice.Application.Roles.Commands.Delete;
public record DeleteRoleCommand(int Id) : IRequest<DeleteRolePayload>;
public record DeleteRolePayload(RoleDto Role);
public class DeleteRoleCommandHandler(IRoleRepository roleRepository,
IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteRoleCommand, DeleteRolePayload>
{
    public async Task<DeleteRolePayload> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await roleRepository.GetRoleByIdAsync(request.Id) ?? throw new NotFoundException(nameof(RoleDto), request.Id);

        await roleRepository.DeleteRoleAsync(entity);
        await unitOfWork.Commit();
        return new DeleteRolePayload(mapper.Map<RoleDto>(entity));
    }
}

