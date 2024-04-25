using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IClientRepository
{
    IQueryable<Client> GetAll { get; }
    Task<Client?> GetClientByIdAsync(int id);
    Task<List<Client>> GetClientAllAsync();
    Task<List<Client?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<Client?> AddClientAsync(Client client);
    Client UpdateClientAsync(Client client);
    Task DeleteClientAsync(Client client);
    Client? GetClientByData(Client clientEntity);
}