using Finanzas.API.Shared.Domain.Models;

namespace Finanzas.API.Clients.Resources;

public class ScheduleResource : IBaseEntity<int>
{
    public int Id { set; get; }
    public string Name { set; get; }
    public DateOnly Date { set; get; }
    public char Coin { set; get; }
    public string Modality { set; get; }
    public int Periods { set; get; }
    public string TypePeriod { set; get; }
    public double PropertyCost { set; get; }
    public float InitialFeePercent { set; get; }
    public double Loan { set; get; }
    public float InterestRate { set; get; }
    public char TypeRate { set; get; }
    public double? MiViviendaBonus { set; get; }
    public double? GoodPayerBonus { set; get; }
}