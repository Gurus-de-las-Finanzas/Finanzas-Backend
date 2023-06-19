using Finanzas.API.Clients.Resources;

namespace Finanzas.API.Clients.Domain.Models;

public class Period : PeriodResource
{
    public Schedule Schedule { set; get; }
    public int ScheduleId { set; get; }
}