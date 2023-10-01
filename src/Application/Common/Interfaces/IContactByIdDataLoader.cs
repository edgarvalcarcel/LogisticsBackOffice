using GreenDonut;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces
{
    public interface IContactByIdDataLoader : IDataLoader<int, Contact>
    {
    }
}
