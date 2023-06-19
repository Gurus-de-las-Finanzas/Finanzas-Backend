using Finanzas.API.Security.Domain.Models;
using Finanzas.API.Shared.Domain.Models;

namespace Finanzas.API.Clients.Domain.Models;

public class Client : IBaseEntity<int>
{
    public int Id { set; get; }
    public string Name { set; get; }
    public string LastName { set; get; }
    public string DNI { set; get; }
    
    public int UserId { set; get; }
    public User User { set; get; }
}