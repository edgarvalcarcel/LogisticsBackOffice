using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Operators.Queries.GetOperators;

public record GetOperatorsQuery() : IRequest<IQueryable<Operator>>; 
