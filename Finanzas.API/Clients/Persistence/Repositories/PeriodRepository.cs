using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Repositories;
using Finanzas.API.Shared.Persistence.Context;
using Finanzas.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Clients.Persistence.Repositories;

public class PeriodRepository : CrudRepository<Period, int>, IPeriodRepository
{
    public PeriodRepository(AppDbContext context) : base(context.Periods)
    {
    }

    public async Task<IEnumerable<Period>> FindByScheduleId(int scheduleId)
    {
        return await DataSet
            .Where(p => p.ScheduleId == scheduleId)
            .ToListAsync();
    }

    public async Task<Period?> FindByScheduleIdAndPeriodNumber(int scheduleId, int periodNumber)
    {
        return (await FindByScheduleId(scheduleId))
            .FirstOrDefault(p => p.NumberPeriod == periodNumber);
    }

    public async Task SaveManyAsync(IEnumerable<Period> periods)
    {
        await DataSet.AddRangeAsync(periods);
    }
}