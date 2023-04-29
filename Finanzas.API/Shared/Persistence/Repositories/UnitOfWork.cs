﻿using Finanzas.API.Shared.Domain.Repositories;
using Finanzas.API.Shared.Persistence.Context;

namespace Finanzas.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}