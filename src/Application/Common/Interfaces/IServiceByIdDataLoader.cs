using LogisticsBackOffice.Domain.Entities;
using GreenDonut;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IServiceByIdDataLoader : IDataLoader<int, Service>
{
}