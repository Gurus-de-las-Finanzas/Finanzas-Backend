using System.ComponentModel.DataAnnotations;

namespace Finanzas.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    public int Age { get; set; }
    public string? Image { get; set; }
    [Required]
    [MaxLength(200)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}