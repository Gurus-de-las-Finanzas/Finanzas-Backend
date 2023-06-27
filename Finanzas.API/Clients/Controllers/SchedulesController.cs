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
public class SchedulesController : CrudController<Schedule, int, ScheduleResource, SaveScheduleResource, UpdateScheduleResource>
{

    private readonly IPeriodService _periodService;
    
    public SchedulesController(IScheduleService scheduleService, IPeriodService periodService, IMapper mapper) : base(scheduleService, mapper)
    {
        _periodService = periodService;
    }
    [HttpGet("{id}")]
    public new async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }
    [HttpPost]
    public new async Task<IActionResult> PostAsync(SaveScheduleResource resource)
    {
        return await base.PostAsync(resource);
    }
    [HttpPut("{id}")]
    public new async Task<IActionResult> PutAsync(int id, UpdateScheduleResource resource)
    {
        return await base.PutAsync(id, resource);
    }
    [HttpDelete("{id}")]
    public new async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }
    
    [HttpGet("{id}/periods")]
    public async Task<IActionResult> GetPeriodsByScheduleId(int id)
    {
        var scheduleResult = await CrudService.FindByIdAsync(id);
        if (!scheduleResult.Success)
            return BadRequestResponse(scheduleResult.Message);

        var periodsResult = await _periodService.FindByScheduleId(id);
        return Ok(periodsResult);
    }

    [HttpGet("{scheduleId}/periods/{periodNumber}")]
    public async Task<IActionResult> GetPeriodByScheduleIdAndPeriodNumber(int scheduleId, int periodNumber)
    {
        var scheduleResult = await CrudService.FindByIdAsync(scheduleId);
        if (!scheduleResult.Success)
            return BadRequestResponse(scheduleResult.Message);

        var periodResult = await _periodService.FindByScheduleIdAndPeriodNumber(scheduleId, periodNumber);
        return !periodResult.Success ? BadRequestResponse(periodResult.Message) : Ok(periodResult.Resource);
    }
}