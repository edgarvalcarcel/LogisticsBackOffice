using LogisticsBackOffice.Domain.Entities;
using GreenDonut;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IOperatorByIdDataLoader : IDataLoader<int, Operator>
{
}