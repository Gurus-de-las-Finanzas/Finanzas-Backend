using AutoMapper;
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
    }
}