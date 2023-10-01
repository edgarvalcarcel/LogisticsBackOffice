using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Projects.Queries.GetProjectById;
public record GetProjectByIdQuery([ID(nameof(Project))] int Id) : IRequest<Project>;
