using LogisticsBackOffice.Application.Common.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class RepositoryAsync<T>(ApplicationDbContext dbContext, IConfiguration configuration) : IRepositoryAsync<T> where T : class
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly IConfiguration _configuration = configuration;

    public IQueryable<T> Entities => _dbContext.Set<T>();

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }
    public T Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.Entry(entity).CurrentValues.SetValues(entity);
        return entity;
    }
    public Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> ExecWithStoreProcedure(string query, params object[] parameters)
    {
        return await _dbContext.Set<T>().FromSqlRaw(query, parameters).AsNoTracking().ToListAsync();
    }

    public async Task<SqlMapper.GridReader> ExecuteSqlDapperMultResults(string query, DynamicParameters parameters)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("ApplicationConnection"));
        connection.Open();
        var result = await connection.QueryMultipleAsync(query, parameters, null, null, commandType: CommandType.Text);
        return result;
    }

    public async Task<List<T>> GetAllAsync()
    {
        var resultEntity = await _dbContext
            .Set<T>()
            .ToListAsync();
        return resultEntity;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var result = await _dbContext.Set<T>().FindAsync(id);
        return result;
    }

    public async Task<List<T?>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        var resultPagedEntity = await _dbContext
            .Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return resultPagedEntity as List<T?>;
    }
}