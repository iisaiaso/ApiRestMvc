using System.Reflection;

namespace ApiMvc.Service.Cores.Context
{
    public  static class BusinessLogicServiceRegistration
    {
        public static IServiceCollection addBusinessLogic(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

           // Para esto siver el Autofac, para las injecciones de dependenci del Service y su implementación
           // services.AddScoped<IProductoService, ProductoService>();
           // services.AddScoped<IFabricanteService, FabricanteService>();
            return services;
        } 
    }
}
