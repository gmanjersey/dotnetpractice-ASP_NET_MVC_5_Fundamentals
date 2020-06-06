using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        public  static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<InMemoryRestaurantData>().As<IRestaurantData>().SingleInstance(); //Singleton would not work for multipl users we would need a Database

                        //Note the DbContext is not a thread safe class so we dont want to have only one for all exeuction of the applicaition
            //We want to set InstancePerRequest (as this is the best practice for any component that implements the Unit of Work Pattern)
            //such as the Entity Framework DbContext:
            builder.RegisterType<SqlRestaurantData>().As<IRestaurantData>().InstancePerRequest();
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();


            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}