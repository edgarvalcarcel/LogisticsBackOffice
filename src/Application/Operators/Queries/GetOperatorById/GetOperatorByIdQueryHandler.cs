using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Contacts.Queries.GetContactById;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Operators.Queries.GetOperatorById;
public class GetOperatorByIdQueryHandler : IRequestHandler<GetOperatorByIdQuery, Operator>
{
    private readonly IOperatorByIdDataLoader _dataLoader;
    public GetOperatorByIdQueryHandler(IOperatorByIdDataLoader dataLoader)
    {
        _dataLoader = dataLoader;
    }
    public async Task<Operator> Handle(GetOperatorByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dataLoader.LoadAsync(request.Id, cancellationToken);
    }
}
