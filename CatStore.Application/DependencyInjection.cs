using System.Reflection;
using CatStore.Application.Common.Behavior;
using CatStore.Application.Mapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CatStore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services
        )
    { 
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(config =>
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetAssembly(typeof(AssemblyMappingProfile)))));
        
        return services;
    }
   
}