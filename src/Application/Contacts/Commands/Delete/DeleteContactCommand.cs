using AutoMapper;
using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;
namespace LogisticsBackOffice.Application.Contacts.Commands.Delete;
public record DeleteContactCommand(int Id) : IRequest<DeleteContactPayload>;
public record DeleteContactPayload(ContactDto Contact);
public class DeleteContactCommandHandler(IContactRepository contactRepository,
 IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteContactCommand, DeleteContactPayload>
{
    public async Task<DeleteContactPayload> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var entity = contactRepository.GetContactById(request.Id) ?? throw new NotFoundException(nameof(ContactDto), request.Id);
        await contactRepository.DeleteContactAsync(entity);
        await unitOfWork.Commit();
        return new DeleteContactPayload(mapper.Map<ContactDto>(entity));
    }
}
