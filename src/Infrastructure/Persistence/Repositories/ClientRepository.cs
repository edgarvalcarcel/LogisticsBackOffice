using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ArgumentNullException = LogisticsBackOffice.Application.Common.Exceptions.ArgumentNullException;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class ClientRepository(IRepositoryAsync<Client> clientRepository,
    IRepositoryAsync<GeographicalInfo> geographicalRepository,
    IUnitOfWork unitOfWork,
    ApplicationDbContext dbContext) : IClientRepository
{
    private readonly IRepositoryAsync<Client> _clientRepository = clientRepository;
    private readonly IRepositoryAsync<GeographicalInfo> _geographicalRepository = geographicalRepository;
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public IQueryable<Client> GetAll => _clientRepository.Entities;
    public async Task<Client?> AddClientAsync(Client client)
    {
        return await _clientRepository.AddAsync(client);
    }
    public async Task<Client?> GetClientByIdAsync(int id)
    {
        Client resultClient = new Client();
        resultClient = await _dbContext.Client
            .AsNoTracking()
            .Where(c => c.Id == id)
            .Include(c => c.GeographicalInfo)
            .ThenInclude(g => g!.State).ThenInclude(s => s!.CountryRegion)
            .OrderBy(c => c.Id).DefaultIfEmpty()
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Client), id);
        return resultClient;
    }
    public async Task<List<Client?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await _clientRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }
    public Client UpdateClientAsync(Client client)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(client.GeographicalInfo);

        _geographicalRepository.Update(client.GeographicalInfo);
        //unitOfWork.Commit();
        return _clientRepository.Update(client);
    }
    public async Task<List<Client>> GetClientAllAsync()
    {
        var resultClients = await _dbContext.Client
            .Include(c => c.GeographicalInfo)
            .ThenInclude(g => g!.State).ThenInclude(s => s!.CountryRegion)
            .AsNoTracking()
            .OrderBy(c => c.Id).ToListAsync() ?? throw new NotFoundException(nameof(List<Client>));
        return resultClients;
    }
    public Task DeleteClientAsync(Client client)
    {
        return _clientRepository.DeleteAsync(client);
    }
    public Client? GetClientByData(Client clientEntity)
    {
        ArgumentNullException.ThrowIfNull(clientEntity);
        ArgumentNullException.ThrowIfNull(clientEntity.FirstName);
        ArgumentNullException.ThrowIfNull(clientEntity.LastName);
        ArgumentNullException.ThrowIfNull(clientEntity.Email);

        var resultClient = _dbContext.Client.Where(c => c.FirstName == clientEntity.FirstName
        && c.LastName == clientEntity.LastName
        && c.Email == clientEntity.Email
        ).FirstOrDefault();
        return resultClient;
    }
}
