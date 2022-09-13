using Autofac;
using Microsoft.Extensions.Configuration;
using Minedu.Comun.Data;
using SISPUN.Api.DataAccess.Context;
using SISPUN.Api.DataAccess.Interface.UniOfWork;
using SISPUN.Api.DataAccess.UnitOfWork; 
using System.Reflection; 

namespace SISPUN.Api.CrossCutting
{
    public class ContextDbModule : Autofac.Module
    {

        public static IConfiguration Configuration;
       
        protected override void Load(ContainerBuilder builder)
        {
            string sispunConnectionString = Configuration.GetSection("ConnectionStrings:AsisPerDBContext").Value;

            //Context           
            builder.RegisterType<SISPUNDbContext>().Named<IDbContext>("asisperContext").WithParameter("connstr", sispunConnectionString).InstancePerLifetimeScope();

            //Resolver UnitOfWork
            builder.RegisterType<SISPUNUnitOfWork>().As<ISISPUNUnitOfWorkAsisPer>().WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("asisperContext"));

 
            var tt = Assembly.Load(new AssemblyName("SISPUN.Api.Aplication"));
            //-> Aplicacion
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("SISPUN.Api.Aplication")))
                .Where(t => t.Name.EndsWith("Service", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("SISPUN.Api.Aplication")))
                .Where(t => t.Name.EndsWith("Config", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("SISPUN.Api.Aplication")))
                .Where(t => t.Name.EndsWith("Caller", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("SISPUN.Api.Aplication")))
                .Where(t => t.Name.EndsWith("Security", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsImplementedInterfaces();
        }
    }
}
