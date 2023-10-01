using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.GeographicalInformation.Commands.AddGeographicalInfo;

public record AddGeographicalInfoCommand(
string? AddressLine1,
string? AddressLine2,
string? City,
int StateId,
string? PostalCode,
string? Latitude,
string? Longitude,
string? LocationName,
string? PhoneNumber) : IRequest<GeographicalInfo>;



