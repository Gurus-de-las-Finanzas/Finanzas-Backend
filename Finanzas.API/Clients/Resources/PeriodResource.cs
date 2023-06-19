using Finanzas.API.Shared.Domain.Models;

namespace Finanzas.API.Clients.Resources;

public class PeriodResource : IBaseEntity<int>
{
    public int Id { get; set; }
    public int NumberPeriod { get; set; }
    public double InitialBalance { get; set; }
    public double Interest { get; set; }
    public double LienInsurance { get; set; }
    public double PropertyInsurance { get; set; }
    public double Fee { get; set; }
    public double Amortization { get; set; }
    public double FinalBalance { get; set; }
}