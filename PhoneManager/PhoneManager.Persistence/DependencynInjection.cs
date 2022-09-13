using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneManager.Application.Interfaces;

namespace PhoneManager.Persistence
{
    public static class DependencynInjection
    {
        public static IServiceCollection AppPersistence(this IServiceCollection services,
           IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<PhoneManagerDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IPhoneManagerDbContext>(provider =>
                provider.GetService<PhoneManagerDbContext>());
            return services;
        }
    }
}
