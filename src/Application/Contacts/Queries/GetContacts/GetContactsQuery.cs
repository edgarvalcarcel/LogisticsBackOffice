using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Queries.GetContacts;

public record GetContactsQuery() : IRequest<IQueryable<Contact>>;
