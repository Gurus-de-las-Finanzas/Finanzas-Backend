using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Repositories;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Shared.Domain.Repositories;
using Finanzas.API.Shared.Domain.Services;
using Finanzas.API.Shared.Domain.Services.Communication;
using Finanzas.API.Shared.Mapping;

namespace Finanzas.API.Clients.Services;

public class PeriodService : CrudService<Period, int>, IPeriodService
{
    private readonly IPeriodRepository _periodRepository;

    public PeriodService(IPeriodRepository periodRepository, IUnitOfWork unitOfWork, IGenericMap<Period, Period> mapper) : base(periodRepository, unitOfWork, mapper)
    {
        _periodRepository = periodRepository;
        EntityName = "Period";
    }

    public Task<IEnumerable<Period>> FindByScheduleId(int scheduleId)
    {
        return _periodRepository.FindByScheduleId(scheduleId);
    }

    public async Task<BaseResponse<Period>> FindByScheduleIdAndPeriodNumber(int scheduleId, int periodNumber)
    {
        var result = await _periodRepository.FindByScheduleIdAndPeriodNumber(scheduleId, periodNumber);
        return result == null ? BaseResponse<Period>.Of("Period with number " + periodNumber + " not found") : BaseResponse<Period>.Of(result);
    }
    
}