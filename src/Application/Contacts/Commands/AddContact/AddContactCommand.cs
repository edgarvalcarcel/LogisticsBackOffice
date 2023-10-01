using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Commands.AddContact;

public record AddContactCommand(
string? Title,
string? FullName,
string? FirstName,
string? LastName,
string? Suffix,
string? Email,
string? Cellphone,
string? AdditionalInfo,
string? Role) : IRequest<Contact>;


