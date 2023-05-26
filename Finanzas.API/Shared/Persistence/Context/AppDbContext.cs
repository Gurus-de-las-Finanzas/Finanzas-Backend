using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Security.Domain.Models;
using Finanzas.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Shared.Persistence.Context;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.Age).IsRequired();
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(200);

        builder.Entity<Client>().ToTable("Clients");
        builder.Entity<Client>().HasKey(p => p.Id);
        builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.DNI).IsRequired().HasMaxLength(8);
        builder.Entity<Client>().Property(p => p.UserId).IsRequired();

        builder.Entity<User>()
            .HasMany(p => p.Clients)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}