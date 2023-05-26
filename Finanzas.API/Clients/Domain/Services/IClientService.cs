using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Services.Communication;

namespace Finanzas.API.Clients.Domain.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> ListByUserIdAsync(int userId);
    Task<ClientResponse> SaveAsync(Client client);
}