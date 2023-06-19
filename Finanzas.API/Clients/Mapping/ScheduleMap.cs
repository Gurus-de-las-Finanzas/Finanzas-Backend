using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Resources.Update;
using Finanzas.API.Shared.Mapping;

namespace Finanzas.API.Clients.Mapping;

public class ScheduleMap : GenericMap<Schedule, UpdateScheduleResource>
{
    public ScheduleMap(IMapper mapper) : base(mapper)
    {
    }
}