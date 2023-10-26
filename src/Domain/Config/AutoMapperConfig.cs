using AutoMapper;
using Pickles.Domain.Events;
using Pickles.Domain.Models;

namespace Pickles.Domain.Config;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<User, UserCreated>().ReverseMap();
        
        this.AddSelfMappingsForTypesInAssembly(typeof(UserCreated).Assembly);
    }
}