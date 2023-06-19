using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Repositories;
using Finanzas.API.Shared.Persistence.Context;
using Finanzas.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Clients.Persistence.Repositories;

public class ScheduleRepository : CrudRepository<Schedule, int>, IScheduleRepository
{
    public ScheduleRepository(AppDbContext context) : base(context.Schedules)
    {
    }

    public async Task<Schedule?> FindByClientIdAsync(int clientId)
    {
        var result =  DataSet
            .Where(s => s.ClientId == clientId);
        return await result.FirstOrDefaultAsync();
    }
}