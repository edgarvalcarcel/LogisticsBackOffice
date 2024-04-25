using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.Services.Commands.Create;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Roles.Commands.Create;

public record CreateRoleCommand : IRequest<CreateRolePayload>
{
    public string? Name { get; init; }
}
public record CreateRolePayload(RoleDto Role);
public class CreateRoleCommandHandler(IRoleRepository roleRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateRoleCommand, CreateRolePayload>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateRolePayload> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var entity = _mapper.Map<Role>(request);
        await _roleRepository.AddRoleAsync(entity);
        await _unitOfWork.Commit();
        return new CreateRolePayload(_mapper.Map<RoleDto>(entity));
    }
}