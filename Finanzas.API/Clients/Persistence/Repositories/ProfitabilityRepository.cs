using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Repositories;
using Finanzas.API.Shared.Persistence.Context;
using Finanzas.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Clients.Persistence.Repositories;

public class ProfitabilityRepository : CrudRepository<Profitability, int>, IProfitabilityRepository
{
    public ProfitabilityRepository(AppDbContext context) : base(context.Profitabilities)
    {
    }

    public async Task<IEnumerable<Profitability>> ListByUserIdAsync(int userId)
    {
        return await DataSet
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }
    
}