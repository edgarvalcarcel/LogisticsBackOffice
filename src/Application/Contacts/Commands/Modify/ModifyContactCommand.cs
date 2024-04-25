using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Commands.Modify;
public record ModifyContactCommand : IRequest<ModifyContactPayload>
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? FullName { get; set; }
    public string? Suffix { get; init; }
    public string? Role { get; init; }
    public required string Email { get; init; }
    public required string Cellphone { get; init; }
    public string? AdditionalInfo { get; init; }
}
public record ModifyContactPayload(ContactDto? Contact);
public class ModifyContactCommandHandler(IContactRepository contactRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<ModifyContactCommand, ModifyContactPayload>
{
    public async Task<ModifyContactPayload> Handle(ModifyContactCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entityContactExist = contactRepository.GetContactById(request.Id);
        if (entityContactExist is null) return new ModifyContactPayload(mapper.Map<ContactDto>(entityContactExist));

        entityContactExist = mapper.Map<Contact>(request);

        contactRepository.UpdateContactAsync(entityContactExist);
        await unitOfWork.Commit();

        return new ModifyContactPayload(mapper.Map<ContactDto>(entityContactExist));
    }
}
