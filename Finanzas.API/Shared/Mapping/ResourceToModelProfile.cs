using AutoMapper;
using Finanzas.API.Clients.Domain.Models;
using Finanzas.API.Clients.Resources;
using Finanzas.API.Security.Domain.Models;
using Finanzas.API.Security.Domain.Services.Communication;

namespace Finanzas.API.Shared.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, Target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && 
                        string.IsNullOrEmpty((string) property)) return false;
                    return true;
                }));
        CreateMap<SaveClientResource, Client>();
    }
}