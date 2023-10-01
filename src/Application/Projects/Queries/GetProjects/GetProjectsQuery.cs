using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Projects.Queries.GetProjects;

public record GetProjectsQuery() : IRequest<IQueryable<Project>>; 
