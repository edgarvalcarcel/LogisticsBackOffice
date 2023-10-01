using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Operators.Queries.GetOperators;

public class GetOperatorsQueryHandler : IRequestHandler<GetOperatorsQuery, IQueryable<Operator>>
{
    private readonly IOperatorRepository _repository;
    public GetOperatorsQueryHandler(IOperatorRepository repository)
    {
        _repository = repository;
    }
    public async Task<IQueryable<Operator>> Handle(GetOperatorsQuery request, CancellationToken cancellationToken)
    {
        return  _repository.GetAllOperators()
            .OrderBy(t => t.FullName);
    }
}
