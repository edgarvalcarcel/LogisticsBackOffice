using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Workers.Commands.Modify;
public record ModifyWorkerCommand : IRequest<ModifyWorkerPayload>
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? FullName { get; set; }
    public string? Suffix { get; init; }
    public string? Role { get; init; }
    public required string Email { get; init; }
    public required string Cellphone { get; init; }
    public string? AdditionalInfo { get; init; }
    public required GeographicalInfoDto GeographicalInfo { get; init; }
}
public record ModifyWorkerPayload(WorkerDto? Worker);
public class ModifyWorkerCommandHandler(IWorkerRepository workerRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<ModifyWorkerCommand, ModifyWorkerPayload>
{
    public async Task<ModifyWorkerPayload> Handle(ModifyWorkerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entityWorkerExist = await workerRepository.GetWorkerByIdAsync(request.Id);
        if (entityWorkerExist is null) return new ModifyWorkerPayload(mapper.Map<WorkerDto>(entityWorkerExist));

        entityWorkerExist = mapper.Map<Worker>(request);
        entityWorkerExist.GeographicalInfo = mapper.Map<GeographicalInfo>(request.GeographicalInfo);

        workerRepository.UpdateWorkerAsync(entityWorkerExist);
        await unitOfWork.Commit();

        return new ModifyWorkerPayload(mapper.Map<WorkerDto>(entityWorkerExist));
    }
}
