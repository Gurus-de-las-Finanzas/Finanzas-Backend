using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Repositories;

namespace Finanzas.API.Clients.Domain.Repositories;

public interface IProfitabilityRepository : ICrudRepository<Profitability, int>
{
    Task<IEnumerable<Profitability>> ListByUserIdAsync(int userId);
}