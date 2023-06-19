using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Domain.Repositories;
using Finanzas.API.Clients.Domain.Services;
using Finanzas.API.Shared.Domain.Repositories;
using Finanzas.API.Shared.Domain.Services;
using Finanzas.API.Shared.Mapping;

namespace Finanzas.API.Clients.Services;

public class ProfitabilityService : CrudService<Profitability, int>, IProfitabilityService
{
    private readonly IProfitabilityRepository _profitabilityRepository;
    public ProfitabilityService(IProfitabilityRepository profitabilityRepository, IUnitOfWork unitOfWork, IGenericMap<Profitability, Profitability> mapper) : 
        base(profitabilityRepository, unitOfWork, mapper)
    {
        _profitabilityRepository = profitabilityRepository;
        EntityName = "Profitability";
    }

    public async Task<IEnumerable<Profitability>> ListByUserIdAsync(int userId)
    {
        return await _profitabilityRepository.ListByUserIdAsync(userId);
    }
}