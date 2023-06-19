using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Resources.Update;
using Finanzas.API.Shared.Mapping;

namespace Finanzas.API.Clients.Mapping;

public class ClientMap : GenericMap<Client, UpdateClientResource>
{
    public ClientMap(IMapper mapper) : base(mapper)
    {
    }
}
