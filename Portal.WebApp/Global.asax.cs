using Autofac;
using Porta.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
namespace Portal.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // First we'll register the MVC/WCF stuff...
            var builder = new ContainerBuilder();

            // MVC - Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // MVC - Set the dependency resolver to be Autofac.
            builder.RegisterType<DbFactory>()
                    .As<IDbFactory>()
                    .InstancePerRequest();

            builder.RegisterGeneric(typeof(GenericPattern<>))
                   .As(typeof(IGenericPattern<>))
                   .InstancePerRequest();

            builder.RegisterGeneric(typeof(UnitofWork<>))
                   .As(typeof(IUnitofWork<>))
                   .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AutoMapperBootStrapper.BootStrap();
        }
    }
}
