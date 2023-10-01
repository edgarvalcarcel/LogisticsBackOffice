using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.GeographicalInformation.Queries.GetStates;
public record GetStatesQuery() : IRequest<IQueryable<State>>; 
