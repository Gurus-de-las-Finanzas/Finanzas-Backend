using System.ComponentModel.DataAnnotations;

namespace Finanzas.API.Clients.Resources.Update;

public class UpdateClientResource
{
    [Required]
    [MaxLength(50)]
    public string Name { set; get; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { set; get; }
    
    [Required]
    [StringLength(8)]
    [MinLength(8)]
    public string DNI { set; get; }
}