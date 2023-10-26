using AutoMapper;
using Pickles.Domain.Config;
using Pickles.Domain.Models;
using Pickles.Infrastructure.Aws.Entities;

namespace Pickles.Infrastructure.Aws.Config;

public class AwsAutoMapperConfig : Profile
{
    public AwsAutoMapperConfig()
    {
        CreateMap<User, UserEntity>().ReverseMap();
        
        this.AddSelfMappingsForTypesInAssembly(typeof(UserEntity).Assembly);
    }
}