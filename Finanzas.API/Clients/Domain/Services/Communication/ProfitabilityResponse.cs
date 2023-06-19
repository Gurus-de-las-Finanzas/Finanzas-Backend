using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Services.Communication;

namespace Finanzas.API.Clients.Domain.Services.Communication;

public class ProfitabilityResponse : BaseResponse<Profitability>
{
    public ProfitabilityResponse(string message) : base(message)
    {
    }

    public ProfitabilityResponse(Profitability resource) : base(resource)
    {
    }
}