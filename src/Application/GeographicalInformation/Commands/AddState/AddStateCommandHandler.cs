using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.GeographicalInformation.Commands.AddState
{
    public class AddStateCommandHandler : IRequestHandler<AddStateCommand, State>
    {
        private readonly IStateRepository _repository;
        public AddStateCommandHandler(IStateRepository repository)
        {
            _repository = repository;
        }
        public async Task<State> Handle(AddStateCommand request, CancellationToken cancellationToken)
        {

            var state = new State
            { 
                Name = request.Name,
                StateCode = request.StateCode,
                CountryRegionId = request.CountryRegionId,
                TerritoryId = request.TerritoryId
            };

            await _repository.AddStateAsync(state, cancellationToken);
            return state;
        }
    }
}
