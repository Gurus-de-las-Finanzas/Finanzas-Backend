using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Repositories;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Shared.Domain.Repositories;
using Finanzas.API.Shared.Domain.Services;
using Finanzas.API.Shared.Domain.Services.Communication;
using Finanzas.API.Shared.Mapping;

namespace Finanzas.API.Clients.Services;

public class ScheduleService : CrudService<Schedule, int>, IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;
    public ScheduleService(IUnitOfWork unitOfWork, IScheduleRepository scheduleRepository, IGenericMap<Schedule, Schedule> mapper) : base(scheduleRepository, unitOfWork, mapper)
    {
        _scheduleRepository = scheduleRepository;
        EntityName = "Schedule";
    }

    public async Task<BaseResponse<Schedule>> FindByClientId(int clientId)
    {
        var result = await _scheduleRepository.FindByClientIdAsync(clientId);
        return result == null ? BaseResponse<Schedule>.Of("Client hasn't schedule") : BaseResponse<Schedule>.Of(result);
    }
}