using Autofac;
using System.Reflection;

namespace ApiMvc.Models.Cores.Context
{
    public class DataAccesAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
