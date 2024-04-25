using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using ArgumentNullException = LogisticsBackOffice.Application.Common.Exceptions.ArgumentNullException;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class ContactRepository(IRepositoryAsync<Contact> contactRepository, ApplicationDbContext dbContext) : IContactRepository
{
    private readonly IRepositoryAsync<Contact> _contactRepository = contactRepository;
    private readonly ApplicationDbContext _dbContext = dbContext;
    public IQueryable<Contact> GetAll => _contactRepository.Entities;
    public async Task<Contact> AddContactAsync(Contact contact)
    {
        return await _contactRepository.AddAsync(contact);
    }
    public Contact GetContactById(int id)
    {
        var resultContact = new Contact();
        resultContact = _dbContext.Contact.Where(c => c.Id == id).FirstOrDefault() ?? throw new NotFoundException(nameof(GeographicalInfo), id);
        return resultContact;
    }
    public async Task<List<Contact?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await _contactRepository.GetPagedReponseAsync(pageNumber, pageSize);
    }
    public Contact UpdateContactAsync(Contact contact)
    {
        return _contactRepository.Update(contact);
    }
    public async Task<List<Contact>> GetContactAllAsync()
    {
        return await _contactRepository.GetAllAsync();
    }
    public Task DeleteContactAsync(Contact contact)
    {
        return _contactRepository.DeleteAsync(contact);
    }

    public Contact? GetContactByData(Contact contactEntity)
    {
        ArgumentNullException.ThrowIfNull(contactEntity);
        ArgumentNullException.ThrowIfNull(contactEntity.FirstName);
        ArgumentNullException.ThrowIfNull(contactEntity.LastName);
        ArgumentNullException.ThrowIfNull(contactEntity.Email);

        var resultContact = _dbContext.Contact.Where(c => c.FirstName == contactEntity.FirstName
        && c.LastName == contactEntity.LastName
        && c.Email == contactEntity.Email
        ).FirstOrDefault();
        return resultContact;
    }
}
