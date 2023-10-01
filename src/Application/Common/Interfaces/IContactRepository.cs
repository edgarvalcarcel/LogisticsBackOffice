using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IContactRepository
{
    Task AddContactAsync(Contact contact, CancellationToken cancellationToken);
    IQueryable<Contact> GetAllContacts();
    Task<Contact?> FindContactByIdAsync(int id, CancellationToken cancellationToken);
    Task UpdateContactAsync(Contact contact, CancellationToken cancellationToken);
}