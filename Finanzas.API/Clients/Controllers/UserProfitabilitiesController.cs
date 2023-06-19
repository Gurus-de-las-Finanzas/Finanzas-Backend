using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Clients.Resources;
using Finanzas.API.Clients.Resources.Save;
using Finanzas.API.Clients.Resources.Update;
using Finanzas.API.Security.Authorization.Attributes;
using Finanzas.API.Security.Domain.Services;
using Finanzas.API.Shared.Controller;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.API.Clients.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/users")]
public class UserProfitabilitiesController : CrudController<Profitability, int, ProfitabilityResource, SaveProfitabilityResource, UpdateProfitabilityResource>
{
    private IProfitabilityService _profitabilityService;
    private IUserService _userService;

    public UserProfitabilitiesController(IProfitabilityService profitabilityService, IUserService userService, IMapper mapper) : base(profitabilityService, mapper)
    {
        _profitabilityService = profitabilityService;
        _userService = userService;
    }

    [HttpGet("{id}/profitabilities")]
    public async Task<IActionResult> GetProfitabilitiesByUserId(int id)
    {
        var _ = await _userService.GetByIdAsync(id);
        return Ok(await _profitabilityService.ListByUserIdAsync(id));
    }
    
    
}