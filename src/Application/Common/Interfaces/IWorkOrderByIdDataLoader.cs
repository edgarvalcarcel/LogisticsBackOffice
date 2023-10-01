using LogisticsBackOffice.Domain.Entities;
using GreenDonut;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IWorkOrderByIdDataLoader : IDataLoader<int, WorkOrder>
{
}