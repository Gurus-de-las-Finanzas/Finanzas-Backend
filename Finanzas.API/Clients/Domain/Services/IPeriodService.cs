using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Services;
using Finanzas.API.Shared.Domain.Services.Communication;

namespace Finanzas.API.Clients.Domain.Services;

public interface IPeriodService : ICrudService<Period, int>
{
    public Task<IEnumerable<Period>> FindByScheduleId(int scheduleId);
    public Task<BaseResponse<Period>> FindByScheduleIdAndPeriodNumber(int scheduleId, int periodNumber);
}