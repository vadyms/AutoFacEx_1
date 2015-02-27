using Autofac;
using Autofac.Integration.Mvc;
using AutoFacEx_1.Controllers;
using AutoFacEx_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoFacEx_1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add( new HandleErrorAttribute() );
        }

        public static void RegisterRoutes( RouteCollection routes )
        {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<ClientService>().As<IClientService>();

            builder.RegisterControllers( typeof( MvcApplication ).Assembly );

            //builder.RegisterType<ClientService>().As<IClientService>().InstancePerHttpRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver( new AutofacDependencyResolver( container ) );



            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory( @"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True" );

            RegisterGlobalFilters( GlobalFilters.Filters );
            RegisterRoutes( RouteTable.Routes );
        }
    }
}