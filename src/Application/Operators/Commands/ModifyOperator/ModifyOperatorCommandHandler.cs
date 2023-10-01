using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Contacts.Commands.ModifyContact;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Operators.Commands.ModifyOperator;
public class ModifyOperatorCommandHandler : IRequestHandler<ModifyOperatorCommand, Operator?>
{
    private readonly IOperatorRepository _repository;
    public ModifyOperatorCommandHandler(IOperatorRepository repository)
    {
        _repository = repository;
    }
    public async Task<Operator?> Handle(ModifyOperatorCommand request, CancellationToken cancellationToken)
    {
        var _operator = await _repository.FindOperatorByIdAsync(request.Id, cancellationToken);

        if (_operator is null) return _operator;

        if (request.Title.HasValue) _operator.Title = request.Title;
        if (request.FullName.HasValue) _operator.FullName = request.FullName;
        if (request.FirstName.HasValue) _operator.FirstName = request.FirstName;
        if (request.LastName.HasValue) _operator.LastName = request.LastName;
 
        if (request.Email.HasValue) _operator.Email = request.Email;
        if (request.Cellphone.HasValue) _operator.Cellphone = request.Cellphone;

        if (request.AdditionalInfo.HasValue) _operator.AdditionalInfo = request.AdditionalInfo;
        if (request.Role.HasValue) _operator.Role = request.Role;
        if (request.GeographicalnfoId.HasValue) _operator.GeographicalnfoId = request.GeographicalnfoId;
        if (request.UserId.HasValue) _operator.UserId = request.UserId;
        await _repository.UpdateOperatorAsync(_operator, cancellationToken);
            return _operator;
    }
}
 
