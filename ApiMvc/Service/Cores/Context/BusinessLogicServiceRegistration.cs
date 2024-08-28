using System.Reflection;

namespace ApiMvc.Service.Cores.Context
{
    public  static class BusinessLogicServiceRegistration
    {
        public static IServiceCollection addBusinessLogic(this IServiceCollection services, Assembly assembly)
        {
            services.AddAutoMapper(assembly);
            // Registrar Service y su implementación
           // services.AddScoped<IProductoService, ProductoService>();
            //services.AddScoped<IFabricanteService, FabricanteService>();
            
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

            return services;
        } 
    }
}
