using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Clients.Resources;
using Finanzas.API.Clients.Resources.Update;
using Finanzas.API.Security.Authorization.Attributes;
using Finanzas.API.Security.Domain.Services;
using Finanzas.API.Shared.Controller;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.API.Clients.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class ClientsController: CrudController<Client, int, ClientResource, SaveClientResource, UpdateClientResource>
{
    private readonly IUserService _userService;
    private readonly IScheduleService _scheduleService;

    public ClientsController(IClientService clientService, IUserService userService, IMapper mapper, IScheduleService scheduleService) : base(
        clientService, mapper)
    {
        _userService = userService;
        _scheduleService = scheduleService;
    }

    [HttpPost]
    public new async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
    {
        /*
         if (!resource.Name.IsNullOrEmpty() && resource.Name.Length <= 50 &&
            !resource.LastName.IsNullOrEmpty() && resource.LastName.Length <= 50 &&
            !resource.DNI.IsNullOrEmpty() && resource.DNI.Length == 8)
            return BadRequest("Fail validation");
        
         */
        var _ = await _userService.GetByIdAsync(resource.UserId);
        return await base.PostAsync(resource);
    }

    [HttpGet("{id}")]
    public new async Task<IActionResult> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    [HttpPut("{id}")]
    public new async Task<IActionResult> PutAsync(int id, UpdateClientResource resource)
    {
        return await base.PutAsync(id, resource);
    }

    [HttpDelete("{id}")]
    public new async Task<IActionResult> DeleteAsync(int id)
    {
        return await base.DeleteAsync(id);
    }

    [HttpGet("{id}/schedule")]
    public async Task<IActionResult> GetScheduleByClientId(int id)
    {
        var client = await CrudService.FindByIdAsync(id);

        if (!client.Success)
            return BadRequestResponse(client.Message);
        
        var result = await _scheduleService.FindByClientId(id);
        return !result.Success ? BadRequestResponse(result.Message) : Ok(result.Resource);
    }
}