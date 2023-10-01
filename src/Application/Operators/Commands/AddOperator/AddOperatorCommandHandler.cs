using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Operators.Commands.AddOperator;
public class AddOperatorCommandHandler : IRequestHandler<AddOperatorCommand, Operator>
{
    private readonly IOperatorRepository _repository;

    public AddOperatorCommandHandler(IOperatorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Operator> Handle(AddOperatorCommand request, CancellationToken cancellationToken)
    {
        var _operator = new Operator
        {
            Title = request.Title,
            FullName = request.FullName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Cellphone = request.Cellphone,AdditionalInfo = request.AdditionalInfo,
            Role = request.Role,
            GeographicalnfoId = request.GeographicalnfoId,
            UserId = request.UserId
        };

        await _repository.AddOperatorAsync(_operator, cancellationToken);
        return _operator;
    }
}


