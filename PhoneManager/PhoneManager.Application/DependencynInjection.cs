using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhoneManager.Application.Common.Behaviors;
using System.Reflection;

namespace PhoneManager.Application
{
    public static class DependencynInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
