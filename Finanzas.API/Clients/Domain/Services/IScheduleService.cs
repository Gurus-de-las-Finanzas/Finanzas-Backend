using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Services;
using Finanzas.API.Shared.Domain.Services.Communication;

namespace Finanzas.API.Clients.Domain.Services;

public interface IScheduleService : ICrudService<Schedule, int>
{
    Task<BaseResponse<Schedule>> FindByClientId(int clientId);
}