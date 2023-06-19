using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Security.Domain.Models;
using Finanzas.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Shared.Persistence.Context;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Profitability> Profitabilities { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Period> Periods { get; set; }

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

        builder.Entity<Profitability>().ToTable("Profitabilities");
        builder.Entity<Profitability>().HasKey(p => p.Id);
        builder.Entity<Profitability>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profitability>().Property(p => p.Npv).IsRequired();
        builder.Entity<Profitability>().Property(p => p.Irr).IsRequired();

        builder.Entity<Period>().ToTable("Periods");
        builder.Entity<Period>().HasKey(p => p.Id);
        builder.Entity<Period>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Period>().Property(p => p.NumberPeriod).IsRequired();
        builder.Entity<Period>().Property(p => p.InitialBalance).IsRequired();
        builder.Entity<Period>().Property(p => p.Interest).IsRequired();
        builder.Entity<Period>().Property(p => p.LienInsurance).IsRequired();
        builder.Entity<Period>().Property(p => p.PropertyInsurance).IsRequired();
        builder.Entity<Period>().Property(p => p.Fee).IsRequired();
        builder.Entity<Period>().Property(p => p.Amortization).IsRequired();
        builder.Entity<Period>().Property(p => p.FinalBalance).IsRequired();

        builder.Entity<Schedule>().ToTable("Schedules");
        builder.Entity<Schedule>().HasKey(s => s.Id);
        builder.Entity<Schedule>()
            .Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder.Entity<Schedule>()
            .Property(s => s.Date)
            .IsRequired()
            .HasConversion(s => s.ToDateTime(TimeOnly.MinValue), s=> s.ToDateOnly());
        builder.Entity<Schedule>().Property(s => s.Coin).IsRequired();
        builder.Entity<Schedule>()
            .Property(s => s.Modality)
            .IsRequired()
            .HasMaxLength(50);
        builder.Entity<Schedule>().Property(s => s.Periods).IsRequired();
        builder.Entity<Schedule>()
            .Property(s => s.TypePeriod)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Entity<Schedule>().Property(s => s.PropertyCost).IsRequired();
        builder.Entity<Schedule>().Property(s => s.InitialFeePercent).IsRequired();
        builder.Entity<Schedule>().Property(s => s.Loan).IsRequired();
        builder.Entity<Schedule>().Property(s => s.InterestRate).IsRequired();
        builder.Entity<Schedule>().Property(s => s.TypeRate).IsRequired();
        builder.Entity<Schedule>().Property(s => s.MiViviendaBonus);
        builder.Entity<Schedule>().Property(s => s.GoodPayerBonus);
        
        builder.Entity<User>()
            .HasMany(p => p.Clients)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        builder.Entity<User>()
            .HasMany<Profitability>()
            .WithOne(p => p.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Client>()
            .HasOne<Schedule>()
            .WithOne(s => s.Client)
            .HasForeignKey<Schedule>(u => u.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Schedule>()
            .HasMany<Period>()
            .WithOne(p => p.Schedule)
            .HasForeignKey(p => p.ScheduleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}