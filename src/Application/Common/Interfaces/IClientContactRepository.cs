using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IClientContactRepository
{
    IQueryable<ClientContact> GetAll { get; }
    Task<ClientContact> AddClientContactAsync(ClientContact clientContact);
    Task DeleteClientContactAsync(ClientContact clientContact);
    Task<List<ClientContact?>> GetPagedReponseAsync(int pageNumber, int pageSize);
    Task<List<ClientContact>> GetClientContactByIdAsync(int clientId);
    ClientContact UpdateClientContactAsync(ClientContact clientContact);
}
