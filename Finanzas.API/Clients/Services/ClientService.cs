using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Repositories;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Shared.Domain.Repositories;
using Finanzas.API.Shared.Domain.Services;
using Finanzas.API.Shared.Mapping;

namespace Finanzas.API.Clients.Services;

public class ClientService : CrudService<Client, int>, IClientService
{
    private readonly IClientRepository _clientRepository;


    public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork, IGenericMap<Client, Client> mapper) 
        : base(clientRepository, unitOfWork, mapper)
    {
        _clientRepository = clientRepository;
        EntityName = "Client";
    }

    public async Task<IEnumerable<Client>> ListByUserIdAsync(int userId)
    {
        return await _clientRepository.ListByUserIdAsync(userId);
    }

}