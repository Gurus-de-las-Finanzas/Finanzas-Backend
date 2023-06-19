using System.ComponentModel.DataAnnotations;
using Finanzas.API.Clients.Resources.Update;

namespace Finanzas.API.Clients.Resources.Save;

public class SaveProfitabilityResource : UpdateProfitabilityResource
{
    [Required]
    public int UserId { get; set; }
}