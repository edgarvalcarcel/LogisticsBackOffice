namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IRepositoryAsync<T> where T : class
{
    IQueryable<T> Entities { get; }
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<List<T?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<T> AddAsync(T entity);
    T Update(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> ExecWithStoreProcedure(string query, params object[] parameters);
}