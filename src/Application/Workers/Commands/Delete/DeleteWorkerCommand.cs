using AutoMapper;
using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Events.ClientEvents;
using MediatR;


namespace LogisticsBackOffice.Application.Workers.Commands.Delete;
//public class DeleteWorkerCommand
public record DeleteWorkerCommand(int Id) : IRequest<DeleteWorkerPayload>;

public record DeleteWorkerPayload(WorkerDto Client);

public class DeleteWorkerCommandHandler(IWorkerRepository workerRepository,
 IGeographicalInfoRepository geoRepository,
IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteWorkerCommand, DeleteWorkerPayload>
{
    public async Task<DeleteWorkerPayload> Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
    {
        var entity = await workerRepository.GetWorkerByIdAsync(request.Id) ?? throw new NotFoundException(nameof(WorkerDto), request.Id);

        var entityGeo = geoRepository.GetGeoInformationById(entity.GeographicalInfoId) ?? throw new NotFoundException(nameof(GeographicalInfoDto), request.Id);

        entityGeo.State = null;
        await geoRepository.DeleteGeoInformationAsync(entityGeo);
        entity.GeographicalInfo = null;
        await workerRepository.DeleteWorkerAsync(entity);

        //entity.AddDomainEvent(new ClientWorkerEvent(entity));
        await unitOfWork.Commit();
        return new DeleteWorkerPayload(mapper.Map<WorkerDto>(entity));
    }
}
