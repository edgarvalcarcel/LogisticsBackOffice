
using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class ClientContactRepository(IRepositoryAsync<ClientContact> clientContactRepository,
    ApplicationDbContext dbContext) : IClientContactRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    public IQueryable<ClientContact> GetAll => clientContactRepository.Entities;
    public async Task<ClientContact> AddClientContactAsync(ClientContact clientContact)
    {
        return await clientContactRepository.AddAsync(clientContact);
    }
    public Task DeleteClientContactAsync(ClientContact clientContact)
    {
        return clientContactRepository.DeleteAsync(clientContact);
    }
    public async Task<List<ClientContact?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await clientContactRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }
    public async Task<List<ClientContact>> GetClientContactByIdAsync(int clientId)
    {
        var resultClientContacts = new List<ClientContact>();
        resultClientContacts = await _dbContext.ClientContact
            .Where(c => c.ClientId == clientId)
            .Include(c => c.Contact).AsNoTracking()
            .OrderBy(c => c.Id).ToListAsync() ?? throw new NotFoundException(nameof(List<ClientContact>));
        return resultClientContacts;
    }
    public ClientContact UpdateClientContactAsync(ClientContact clientContact)
    {
        return clientContactRepository.Update(clientContact);
    }
}
