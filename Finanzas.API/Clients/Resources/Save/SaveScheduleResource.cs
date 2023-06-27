using System.ComponentModel.DataAnnotations;
using Finanzas.API.Clients.Resources.Update;

namespace Finanzas.API.Clients.Resources.Save;

public class SaveScheduleResource : UpdateScheduleResource
{
    [Required]
    public int ClientId { get; set; }
}