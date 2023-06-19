﻿using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Repositories;
using Finanzas.API.Shared.Persistence.Context;
using Finanzas.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Clients.Persistence.Repositories;

public class ClientRepository: CrudRepository<Client, int>, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context.Clients)
    {
    }

    public async Task<IEnumerable<Client>> ListByUserIdAsync(int userId)
    {
        return await DataSet
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }
    
}