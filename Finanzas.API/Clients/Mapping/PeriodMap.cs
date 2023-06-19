using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Resources.Update;
using Finanzas.API.Shared.Mapping;

namespace Finanzas.API.Clients.Mapping;

public class PeriodMap : GenericMap<Period, UpdatePeriodResource>
{
    public PeriodMap(IMapper mapper) : base(mapper)
    {
    }
}