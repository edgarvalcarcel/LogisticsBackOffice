using LogisticsBackOffice.Domain.Entities;
using GreenDonut;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IGeographicalInfoByIdDataLoader : IDataLoader<int, GeographicalInfo>
{
}