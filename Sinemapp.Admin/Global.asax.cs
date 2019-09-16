using Autofac;
using Autofac.Integration.Mvc;
using Sinemapp.Data;
using Sinemapp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sinemapp.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.Register(c => HttpContext.Current).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<CastService>().As<ICastService>();
            builder.RegisterType<FilmService>().As<IFilmService>();
            builder.RegisterType<NewsService>().As<INewsService>();
            builder.RegisterType<TvSerieService>().As<ITvSerieService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            new AutoMapperConfig().Initialize();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
