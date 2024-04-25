namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IUnitOfWork : IDisposable
{
    Task<int> Commit();
    Task Rollback();
}