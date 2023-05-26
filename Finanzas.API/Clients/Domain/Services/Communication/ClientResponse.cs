using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Services.Communication;

namespace Finanzas.API.Clients.Domain.Services.Communication;

public class ClientResponse: BaseResponse<Client>
{
    public ClientResponse(string message) : base(message)
    {
    }

    public ClientResponse(Client resource) : base(resource)
    {
    }
}