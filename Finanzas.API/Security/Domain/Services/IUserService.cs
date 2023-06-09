﻿using Finanzas.API.Security.Domain.Models;
using Finanzas.API.Security.Domain.Services.Communication;

namespace Finanzas.API.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task RegisterAsync(RegisterRequest request);
    
    Task<User> FindByEmailAsync(string email);
    Task UpdateAsync(int id, UpdateRequest request);
    Task DeleteAsync(int id);
}