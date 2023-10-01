using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Commands.ModifyContact;

public class ModifyContactCommandHandler : IRequestHandler<ModifyContactCommand, Contact?>
{
    private readonly IContactRepository _repository;

    public ModifyContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact?> Handle(ModifyContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _repository.FindContactByIdAsync(request.Id, cancellationToken);

        if (contact is null) return contact;

        if (request.Title.HasValue) contact.Title = request.Title;
        if (request.FullName.HasValue) contact.FullName = request.FullName;
        if (request.FirstName.HasValue) contact.FirstName = request.FirstName;
        if (request.LastName.HasValue) contact.LastName = request.LastName;
        if (request.Suffix.HasValue) contact.Suffix = request.Suffix;
        if (request.Email.HasValue) contact.Email = request.Email;
        if (request.Cellphone.HasValue) contact.Cellphone = request.Cellphone;

        if (request.AdditionalInfo.HasValue) contact.AdditionalInfo = request.AdditionalInfo;
        if (request.Role.HasValue) contact.Role = request.Role;
 
        await _repository.UpdateContactAsync(contact, cancellationToken);
            return contact;
    }
}