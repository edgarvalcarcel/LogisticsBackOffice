using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
namespace LogisticsBackOffice.Application.Statuses.Commands.Modify;
public class ModifyStatusCommand : IRequest<ModifyStatusPayload>
{
    public int Id { get; init; }
    public string? Name { get; init; }
}
public record ModifyStatusPayload(StatusDto? Status);
public class ModifyStatusCommandHandler(IStatusRepository statusRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<ModifyStatusCommand, ModifyStatusPayload>
{
    public async Task<ModifyStatusPayload> Handle(ModifyStatusCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entityStatusExist = await statusRepository.GetStatusByIdAsync(request.Id);
        if (entityStatusExist is null) return new ModifyStatusPayload(mapper.Map<StatusDto>(entityStatusExist));

        entityStatusExist = mapper.Map<Status>(request);

        statusRepository.UpdateStatusAsync(entityStatusExist);
        await unitOfWork.Commit();

        return new ModifyStatusPayload(mapper.Map<StatusDto>(entityStatusExist));
    }
}