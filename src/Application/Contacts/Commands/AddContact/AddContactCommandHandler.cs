using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Commands.AddContact;

public class AddContactCommandHandler : IRequestHandler<AddContactCommand, Contact>
{
    private readonly IContactRepository _repository;
    public AddContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }
    public async Task<Contact> Handle(AddContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            Title = request.Title,
            FullName = request.FullName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Suffix = request.Suffix,
            Email = request.Email,
            Cellphone = request.Cellphone,
            AdditionalInfo = request.AdditionalInfo,
            Role = request.Role
        };
        await _repository.AddContactAsync(contact, cancellationToken);
        return contact;
    }
}
