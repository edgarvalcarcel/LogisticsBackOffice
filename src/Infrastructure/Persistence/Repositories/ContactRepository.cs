using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;

internal class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddContactAsync(Contact contact, CancellationToken cancellationToken)
    {
        await _context.Contacts.AddAsync(contact, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Contact> GetAllContacts()
    {
        return _context.Contacts
            .AsQueryable()
            .AsNoTracking();
    }

    public async Task<Contact?> FindContactByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Contacts.FirstOrDefaultAsync(
            t => t.Id == id, cancellationToken);
    }

    public async Task UpdateContactAsync(Contact contact, CancellationToken cancellationToken)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync(cancellationToken);
    }
}