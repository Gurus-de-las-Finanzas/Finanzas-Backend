using System.ComponentModel.DataAnnotations;
using Finanzas.API.Clients.Resources.Update;

namespace Finanzas.API.Clients.Resources;

public class SaveClientResource : UpdateClientResource
{
    [Required]
    public int UserId { set; get; }
}