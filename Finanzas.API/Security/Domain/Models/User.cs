using Finanzas.API.Clients.Domain.Models;

namespace Finanzas.API.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string? Image { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public IList<Client> Clients { get; set; } = new List<Client>();
}