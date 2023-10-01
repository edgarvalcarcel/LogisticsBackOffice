using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Operators.Queries.GetOperatorById;

public record GetOperatorByIdQuery([ID(nameof(Operator))] int Id) : IRequest<Operator>;
