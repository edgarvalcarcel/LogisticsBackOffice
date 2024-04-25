using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Commands.Modify;
public record ModifyClientCommand : IRequest<ModifyClientPayload>
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? FullName { get; set; }
    public string? Suffix { get; init; }
    public required string Email { get; init; }
    public required string Cellphone { get; init; }
    public string? AdditionalInfo { get; init; }
    public required GeographicalInfoDto GeographicalInfo { get; init; }
}
public record ModifyClientPayload(ClientDto? Client);
public class ModifyClientCommandHandler(IClientRepository clientRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<ModifyClientCommand, ModifyClientPayload>
{
    public async Task<ModifyClientPayload> Handle(ModifyClientCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entityClientExist = await clientRepository.GetClientByIdAsync(request.Id);
        if (entityClientExist is null) return new ModifyClientPayload(mapper.Map<ClientDto>(entityClientExist));

        entityClientExist = mapper.Map<Client>(request);
        entityClientExist.GeographicalInfo = mapper.Map<GeographicalInfo>(request.GeographicalInfo);

        clientRepository.UpdateClientAsync(entityClientExist);
        await unitOfWork.Commit();

        return new ModifyClientPayload(mapper.Map<ClientDto>(entityClientExist));
    }
}