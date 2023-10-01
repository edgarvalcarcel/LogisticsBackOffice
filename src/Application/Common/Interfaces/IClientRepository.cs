using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IClientRepository
{
    Task AddClientAsync(Client client, CancellationToken cancellationToken);
    IQueryable<Client> GetAllClients();
    Task<Client?> FindClientByIdAsync(int id, CancellationToken cancellationToken);
    Task UpdateClientAsync(Client client, CancellationToken cancellationToken);
}