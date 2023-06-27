using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Clients.Resources;
using Finanzas.API.Clients.Resources.Save;
using Finanzas.API.Clients.Resources.Update;
using Finanzas.API.Security.Authorization.Attributes;
using Finanzas.API.Shared.Controller;
using Finanzas.API.Shared.Domain.Services.Communication;
using Finanzas.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.API.Clients.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class PeriodsController : CrudController<Period, int, PeriodResource, SavePeriodResource, UpdatePeriodResource>
{
    private readonly IPeriodService _periodService;
    
    public PeriodsController(IPeriodService periodService, IMapper mapper) : base(periodService, mapper)
    {
        _periodService = periodService;
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

    [HttpPost("many")]
    public async Task<IActionResult> SaveManyAsync([FromBody] IEnumerable<SavePeriodResource> periodResources)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var result = await _periodService.SaveManyAsync(Mapper.Map<IEnumerable<Period>>(periodResources));
        return !result.Success ? BadRequestResponse(result.Message) : Created(nameof(SaveManyAsync), ErrorResponse.Of("All saved"));
    }
}