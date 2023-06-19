using Finanzas.API.Clients.Resources;

namespace Finanzas.API.Clients.Domain.Models;

public class Schedule : ScheduleResource
{
    public int ClientId { set; get; }
    public Client Client { set; get; }
}