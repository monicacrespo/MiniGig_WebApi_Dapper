namespace MiniGigWebApi
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;
    using AutoMapper;
    using MiniGigWebApi.Data.Dapper;
    using MiniGigWebApi.Domain;

    public class AutofacConfig
    {
        public static void Register()
        {          
            var bldr = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            bldr.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(bldr);
            bldr.RegisterWebApiFilterProvider(config);
            bldr.RegisterWebApiModelBinderProvider();
            var container = bldr.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder bldr)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GigMappingProfile());
            });

            bldr.RegisterInstance(config.CreateMapper())
              .As<IMapper>()
              .SingleInstance();

            //Database connection
            var connectionString = ConfigurationManager.ConnectionStrings["MiniGigConnection"].ConnectionString;
            bldr.Register(ctx => new SqlConnection(connectionString)).As<IDbConnection>().InstancePerLifetimeScope();

            //Repositories
            bldr.RegisterType<AsyncGigRepository>()
                .As<IAsyncGigRepository>()
                .InstancePerLifetimeScope();
        }
    }
}