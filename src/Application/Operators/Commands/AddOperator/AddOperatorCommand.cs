using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Operators.Commands.AddOperator;
public record AddOperatorCommand(string? Title,
string? FullName,
string? FirstName,
string? LastName,
string? Email,
string? Cellphone,
string? AdditionalInfo,
string? Role,
int GeographicalnfoId,
int UserId) : IRequest<Operator>;