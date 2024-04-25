using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IContactRepository
{
    IQueryable<Contact> GetAll { get; }
    Contact GetContactById(int id);
    Task<List<Contact>> GetContactAllAsync();
    Task<List<Contact?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<Contact> AddContactAsync(Contact contact);
    Contact UpdateContactAsync(Contact contact);
    Task DeleteContactAsync(Contact contact);
    Contact? GetContactByData(Contact contactEntity);
}
