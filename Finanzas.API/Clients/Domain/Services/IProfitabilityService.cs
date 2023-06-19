using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Services;

namespace Finanzas.API.Clients.Domain.Services;

public interface IProfitabilityService : ICrudService<Profitability, int>
{
    Task<IEnumerable<Profitability>> ListByUserIdAsync(int userId);
    
}