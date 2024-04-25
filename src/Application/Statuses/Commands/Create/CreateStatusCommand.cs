using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
namespace LogisticsBackOffice.Application.Statuses.Commands.Create;
public record CreateStatusCommand : IRequest<CreateStatusPayload>
{
    public string? Name { get; init; }
}
public record CreateStatusPayload(StatusDto Status);
public class CreateStatusCommandHandler(IStatusRepository statusRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateStatusCommand, CreateStatusPayload>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IStatusRepository _statusRepository = statusRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateStatusPayload> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var entity = _mapper.Map<Status>(request);
        await _statusRepository.AddStatusAsync(entity);
        await _unitOfWork.Commit();
        return new CreateStatusPayload(_mapper.Map<StatusDto>(entity));
    }
}