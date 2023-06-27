using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Repositories;

namespace Finanzas.API.Clients.Domain.Repositories;

public interface IPeriodRepository : ICrudRepository<Period, int>
{
    public Task<IEnumerable<Period>> FindByScheduleId(int scheduleId);
    public Task<Period?> FindByScheduleIdAndPeriodNumber(int scheduleId, int periodNumber);

    public Task SaveManyAsync(IEnumerable<Period> periods);
}