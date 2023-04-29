using Finanzas.API.Security.Domain.Models;

namespace Finanzas.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(User user);
    int? ValidateToken(string token);
}