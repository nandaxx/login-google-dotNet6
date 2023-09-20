using Domain.Repositories;
using InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
           
            return services;
        }
    }
}
