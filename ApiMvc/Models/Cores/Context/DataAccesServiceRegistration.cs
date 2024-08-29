using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiMvc.Models.Cores.Context
{
    public static class DataAccesServiceRegistration
    {
        public static IServiceCollection addDataAcces(this IServiceCollection services, IConfiguration configuration)
        {
            // Registrar Repository y su implementación
            // services.AddScoped<IProductoRepository, ProductoRepository>();
            // services.AddScoped<IFabricanteRepository, FabricanteRepository>();

            services.AddDbContext<AppDataBaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            return services;
        }
    }
}
