using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Resources.Update;
using Finanzas.API.Shared.Mapping;

namespace Finanzas.API.Clients.Mapping;

public class ProfitabilityMap : GenericMap<Profitability, UpdateProfitabilityResource> {
    public ProfitabilityMap(IMapper mapper) : base(mapper) {}
}