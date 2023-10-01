using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Commands.AddClient;
public record AddClientCommand(
    string? Title,
    string? FullName,
    string? FirstName,
    string? LastName,
    string? Suffix,
    string? Email,
    string? Cellphone,
    GeographicalInfo? Geographicalnfo) : IRequest<Client>;