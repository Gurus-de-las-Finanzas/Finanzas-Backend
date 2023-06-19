using System.ComponentModel.DataAnnotations;

namespace Finanzas.API.Clients.Resources.Update;

public class UpdateProfitabilityResource
{
    [Required]
    public double Npv { set; get; }
    [Required]
    public float Irr { set; get; }
}