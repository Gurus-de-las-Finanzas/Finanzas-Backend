using System.ComponentModel.DataAnnotations;

namespace Finanzas.API.Clients.Resources.Update;

public class UpdateScheduleResource
{
    [Required]
    [MaxLength(50)]
    public string Name { set; get; }
    
    [Required]
    public DateOnly Date { set; get; }
    
    [Required]
    public char Coin { set; get; }
    
    [Required]
    [MaxLength(50)]
    public string Modality { set; get; }
    
    [Required]
    public int Periods { set; get; }
    
    [Required]
    [MaxLength(50)]
    public string TypePeriod { set; get; }
    
    [Required]
    public double PropertyCost { set; get; }
    
    [Required]
    public float InitialFeePercent { set; get; }
    
    [Required]
    public double Loan { set; get; }
    
    [Required]
    public float InterestRate { set; get; }
    
    [Required]
    public char TypeRate { set; get; }
    
    
    public int? GraceMonths { set; get; }
    
    public char? GracePeriod { set; get; }
    
    public double? MiViviendaBonus { set; get; }
    public double? GoodPayerBonus { set; get; }
}