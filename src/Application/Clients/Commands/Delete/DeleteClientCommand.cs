using AutoMapper;
using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Events.ClientEvents;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Commands.Delete;

public record DeleteClientCommand(int Id) : IRequest<DeleteClientPayload>;

public record DeleteClientPayload(ClientDto Client);

public class DeleteClientCommandHandler(IClientRepository clientRepository,
 IGeographicalInfoRepository geoRepository,
IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteClientCommand, DeleteClientPayload>
{
    public async Task<DeleteClientPayload> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var entity = await clientRepository.GetClientByIdAsync(request.Id) ?? throw new NotFoundException(nameof(ClientDto), request.Id);

        var entityGeo = geoRepository.GetGeoInformationById(entity.GeographicalInfoId) ?? throw new NotFoundException(nameof(GeographicalInfoDto), request.Id);

        entityGeo.State = null;
        await geoRepository.DeleteGeoInformationAsync(entityGeo);
        entity.GeographicalInfo = null;
        await clientRepository.DeleteClientAsync(entity);

        entity.AddDomainEvent(new ClientDeletedEvent(entity));
        await unitOfWork.Commit();
        return new DeleteClientPayload(mapper.Map<ClientDto>(entity));
    }
}
