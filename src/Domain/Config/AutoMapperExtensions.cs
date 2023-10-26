using System.Reflection;
using AutoMapper;

namespace Pickles.Domain.Config;

public static class AutoMapperExtensions
{
    public static void AddSelfMappingsForTypesInAssembly(this Profile profile, Assembly assembly)
    {
        assembly.GetTypes().Where(t => t.IsClass && t.BaseType != typeof(Exception))
            .ToList()
            .ForEach(type => profile.CreateMap(type, type));
    }
}