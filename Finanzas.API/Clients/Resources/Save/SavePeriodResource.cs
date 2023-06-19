using System.ComponentModel.DataAnnotations;
using Finanzas.API.Clients.Resources.Update;

namespace Finanzas.API.Clients.Resources.Save;

public class SavePeriodResource : UpdatePeriodResource
{
    
    [Required]
    public int ScheduleId { get; set; }
}