using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Repositories;

namespace Finanzas.API.Clients.Domain.Repositories;

public interface IScheduleRepository : ICrudRepository<Schedule, int>
{
    Task<Schedule?> FindByClientIdAsync(int clientId);
}