using AutoMapper;
using Pickles.Domain.Entities;
using Pickles.Domain.Events;
using Pickles.Domain.Models;

namespace Pickles.Domain.Config;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<User, UserEntity>().ReverseMap();
        CreateMap<User, UserCreated>().ReverseMap();
        
        AddSelfMapping();
    }

    private void AddSelfMapping()
    {
        var models = typeof(UserEntity).Assembly;
        models.GetTypes().Where(t => t.IsClass && t.BaseType != typeof(Exception))
            .ToList()
            .ForEach(type => CreateMap(type, type));
    }
}