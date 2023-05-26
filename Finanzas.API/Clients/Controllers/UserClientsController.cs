using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Clients.Resources;
using Finanzas.API.Security.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Finanzas.API.Clients.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/users/{userId}/clients")]
public class UserClientsController
{
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;

    public UserClientsController(IClientService clientService, IMapper mapper)
    {
        _clientService = clientService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ClientResource>> GetAllClientsByUserId(int userId)
    {
        var clients = await _clientService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
        return resources;
    }
}