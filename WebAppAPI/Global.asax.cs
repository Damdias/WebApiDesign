using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using webapi.core;
using webapi.core.Entities;
using webapi.data;
using webapi.data.Repository;
using webapi.services;

namespace WebAppAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterType<ProductDBContext>().As<ProductDBContext>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductUnitOfwork>().As<IUnitOfWork>();
            //builder.RegisterType<IUnitOfWork, ProductUnitOfwork>();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
