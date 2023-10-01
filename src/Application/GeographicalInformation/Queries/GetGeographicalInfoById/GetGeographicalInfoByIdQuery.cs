using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.GeographicalInformation.Queries.GetGeographicalInfoById;

public record GetGeographicalInfoByIdQuery([ID(nameof(GeographicalInfo))] int Id) : IRequest<GeographicalInfo>;