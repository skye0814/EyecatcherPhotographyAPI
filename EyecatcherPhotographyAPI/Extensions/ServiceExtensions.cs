using Core.Interface.Repository;
using Infrastructure.Data.Repository;
using System.Runtime.CompilerServices;

namespace EyecatcherPhotographyAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<RepositoryWrapper>();
        }
    }
}
