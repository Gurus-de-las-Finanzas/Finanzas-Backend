using System.ComponentModel.DataAnnotations;

namespace Finanzas.API.Clients.Resources;

public class SaveClientResource
{
    [Required]
    [MaxLength(50)]
    public string Name { set; get; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { set; get; }
    
    [Required]
    [StringLength(8)]
    public string DNI { set; get; }
    
    [Required]
    public int UserId { set; get; }
}