using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Resources;
using Finanzas.API.Clients.Resources.Update;
using Finanzas.API.Security.Domain.Models;
using Finanzas.API.Security.Domain.Services.Communication;
using Finanzas.API.Security.Resources;

namespace Finanzas.API.Shared.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
        CreateMap<Client, ClientResource>();
        CreateMap<Profitability, ProfitabilityResource>();
        CreateMap<Schedule, ScheduleResource>();
        CreateMap<Period, PeriodResource>();
        
        CreateMap<Profitability, UpdateProfitabilityResource>();
        CreateMap<Client, UpdateClientResource>();
        CreateMap<Schedule, UpdateScheduleResource>();
        CreateMap<Period, UpdatePeriodResource>();
    }
}