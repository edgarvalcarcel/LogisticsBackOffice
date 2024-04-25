using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Commands.Create;
public record CreateContactCommand : IRequest<CreateContactPayload>
{
    //public int Id { get; set; }
    public string? Title { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? FullName { get; set; }
    public string? Suffix { get; init; }
    public string? Email { get; init; }
    public string? Role { get; init; }
    public string? Cellphone { get; init; }
    public string? AdditionalInfo { get; init; }
}
public record CreateContactPayload(ContactDto Worker);

public class CreateContactCommandHandler(IContactRepository contactRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateContactCommand, CreateContactPayload>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IContactRepository _contactRepository = contactRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<CreateContactPayload> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var entity = _mapper.Map<Contact>(request);
        await _contactRepository.AddContactAsync(entity);
        await _unitOfWork.Commit();
        return new CreateContactPayload(_mapper.Map<ContactDto>(entity));
    }
}