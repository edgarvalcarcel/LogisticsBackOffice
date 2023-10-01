using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.GeographicalInformation.Queries.GetStates;

public class GetStatesQueryHandler : IRequestHandler<GetStatesQuery, IQueryable<State>>
{
    private readonly IStateRepository _repository;
    public GetStatesQueryHandler(IStateRepository repository)
    {
        _repository = repository;
    }
    public async Task<IQueryable<State>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAllStates()
            .OrderBy(t => t.Name);
    }
}
