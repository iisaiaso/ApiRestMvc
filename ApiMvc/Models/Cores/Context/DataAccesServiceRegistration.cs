using ApiMvc.Models.Contracts;
using ApiMvc.Models.Cores.Persistences;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiMvc.Models.Cores.Context
{
    public static class DataAccesServiceRegistration
    {
        public static IServiceCollection addDataAcces(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
        {
            // Registrar Repository y su implementación
            // services.AddScoped<IProductoRepository, ProductoRepository>();
            // services.AddScoped<IFabricanteRepository, FabricanteRepository>();

            // Obtener todos los tipos públicos del ensamblado proporcionado
            var types = assembly.GetExportedTypes();

            // Buscar todos los tipos que son interfaces y sus implementaciones concretas
            foreach (var type in types)
            {
                if (type.IsInterface)
                {
                    var implementation = types.FirstOrDefault(t => t.IsClass && !t.IsAbstract && type.IsAssignableFrom(t));
                    if (implementation != null)
                    {
                        services.AddScoped(type, implementation);
                    }
                }
            }

            services.AddDbContext<AppDataBaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            return services;
        }
    }
}
