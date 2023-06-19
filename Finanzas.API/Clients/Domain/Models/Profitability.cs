using Finanzas.API.Clients.Resources;
using Finanzas.API.Security.Domain.Models;
using Finanzas.API.Shared.Domain.Models;

namespace Finanzas.API.Clients.Domain.Models;

public class Profitability : ProfitabilityResource, IBaseEntity<int>
{
    public User User { set; get; }
    public int UserId { set; get; }
}