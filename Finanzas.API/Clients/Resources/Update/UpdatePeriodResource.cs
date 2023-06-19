using System.ComponentModel.DataAnnotations;

namespace Finanzas.API.Clients.Resources.Update;

public class UpdatePeriodResource
{
    [Required]
    public int NumberPeriod { get; set; }
    
    [Required]
    public double InitialBalance { get; set; }
    
    [Required]
    public double Interest { get; set; }
    
    [Required]
    public double LienInsurance { get; set; }
    
    [Required]
    public double PropertyInsurance { get; set; }
    
    [Required]
    public double Fee { get; set; }
    
    [Required]
    public double Amortization { get; set; }
    
    [Required]
    public double FinalBalance { get; set; }
}