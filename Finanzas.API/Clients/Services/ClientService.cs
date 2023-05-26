using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Repositories;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Clients.Domain.Services.Communication;
using Finanzas.API.Security.Domain.Repositories;
using Finanzas.API.Shared.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace Finanzas.API.Clients.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;


    public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Client>> ListByUserIdAsync(int userId)
    {
        return await _clientRepository.ListByUserIdAsync(userId);
    }

    public async Task<ClientResponse> SaveAsync(Client client)
    {
        var existingUser = await _userRepository.FindByIdAsync(client.UserId);
        if (existingUser == null)
            return new ClientResponse("Invalid User");

        if (!client.Name.IsNullOrEmpty() && client.Name.Length <= 50 &&
            !client.LastName.IsNullOrEmpty() && client.LastName.Length <= 50 &&
            !client.DNI.IsNullOrEmpty() && client.DNI.Length == 8)
        {
            try
            {
                await _clientRepository.AddAsync(client);
                await _unitOfWork.CompleteAsync();
                return new ClientResponse(client);
            }
            catch (Exception e)
            {
                return new ClientResponse($"An error occurred while saving the client: {e.Message}");
            }
        }
        return new ClientResponse("Validation error.");
    }
}