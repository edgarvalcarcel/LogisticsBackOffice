using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Commands.AddClient;

public class AddClientCommandHandler : IRequestHandler<AddClientCommand, Client>
{
    private readonly IClientRepository _repository;

    public AddClientCommandHandler(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<Client> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client
        {
            Title = request.Title,
            FullName = request.FullName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Suffix = request.Suffix,
            Email = request.Email,
            Cellphone = request.Cellphone,
            Geographicalnfo = request.Geographicalnfo
        };

        await _repository.AddClientAsync(client, cancellationToken);
        return client;
    }
}