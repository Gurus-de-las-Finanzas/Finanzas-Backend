using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Clients.Resources;
using Finanzas.API.Clients.Resources.Save;
using Finanzas.API.Clients.Resources.Update;
using Finanzas.API.Security.Authorization.Attributes;
using Finanzas.API.Shared.Controller;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.API.Clients.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class PeriodsController : CrudController<Period, int, PeriodResource, SavePeriodResource, UpdatePeriodResource>
{
    
    public PeriodsController(IPeriodService periodService, IMapper mapper) : base(periodService, mapper)
    {
    }


    [HttpPost]
    public new async Task<IActionResult> PostAsync(SavePeriodResource resource)
    {
        return await base.PostAsync(resource);
    }
    
    [HttpPut("{id}")]
    public new async Task<IActionResult> PutAsync(int id, UpdatePeriodResource resource)
    {
        return await base.PutAsync(id, resource);
    }
    [HttpDelete("{id}")]
    public new async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }

    [HttpGet("{id}")]
    public new async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }
}