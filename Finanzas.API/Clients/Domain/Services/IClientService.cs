using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Services;

namespace Finanzas.API.Clients.Domain.Services;

public interface IClientService : ICrudService<Client, int>
{
    Task<IEnumerable<Client>> ListByUserIdAsync(int userId);
}