using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Operators.Queries.GetOperators;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Services.Queries.GetServices;

public class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, IQueryable<Service>>
{
    private readonly IServiceRepository _repository;
    public GetServicesQueryHandler(IServiceRepository repository)
    {
        _repository = repository;
    }
    public async Task<IQueryable<Service>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetAllServices()
            .OrderBy(t => t.Id);
    }
}

