using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Commands.ModifyClient;

public class ModifyClientCommandHandler : IRequestHandler<ModifyClientCommand, Client?>
{
    private readonly IClientRepository _repository;

    public ModifyClientCommandHandler(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<Client?> Handle(ModifyClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _repository.FindClientByIdAsync(request.Id, cancellationToken);

        if (client is null) return client;

        if (request.Title.HasValue) client.Title = request.Title;
        if (request.FullName.HasValue) client.FullName = request.FullName;
        if (request.FirstName.HasValue) client.FirstName = request.FirstName;
        if (request.LastName.HasValue) client.LastName = request.LastName;
        if (request.Suffix.HasValue) client.Suffix = request.Suffix;
        if (request.Email.HasValue) client.Email = request.Email;
        if (request.Cellphone.HasValue) client.Cellphone = request.Cellphone;
        if (request.Geographicalnfo.HasValue) client.Geographicalnfo = request.Geographicalnfo;

        await _repository.UpdateClientAsync(client, cancellationToken);
        return client;
    }
}