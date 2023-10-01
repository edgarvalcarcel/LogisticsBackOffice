using LogisticsBackOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IStateRepository
{
    Task AddStateAsync(State state, CancellationToken cancellationToken);
    IQueryable<State> GetAllStates();
    Task<State?> FindStateByIdAsync(int id, CancellationToken cancellationToken);
    Task UpdateStateAsync(State state, CancellationToken cancellationToken);
}
