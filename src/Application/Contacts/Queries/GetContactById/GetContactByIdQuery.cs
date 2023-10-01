using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Queries.GetContactById;
public record GetContactByIdQuery([ID(nameof(Contact))] int Id) : IRequest<Contact>; 
