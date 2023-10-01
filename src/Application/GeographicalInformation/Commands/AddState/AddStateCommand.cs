using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.GeographicalInformation.Commands.AddState;

public record AddStateCommand(string Name,string StateCode,
    int CountryRegionId, int TerritoryId) : IRequest<State>;