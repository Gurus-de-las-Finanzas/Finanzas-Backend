using Finanzas.API.Clients.Domain.Models;

namespace Finanzas.API.Clients.Domain.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> ListByUserIdAsync(int userId);
    Task AddAsync(Client client);
}