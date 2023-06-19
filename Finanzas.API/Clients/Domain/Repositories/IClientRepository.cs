﻿using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Shared.Domain.Repositories;

namespace Finanzas.API.Clients.Domain.Repositories;

public interface IClientRepository : ICrudRepository<Client, int>
{
    Task<IEnumerable<Client>> ListByUserIdAsync(int userId);
}