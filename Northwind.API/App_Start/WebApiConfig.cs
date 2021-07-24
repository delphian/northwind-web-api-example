using Northwind.API;
using Northwind.Datastore;
using Northwind.Datastore.CustomerOrders;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using Unity;

namespace Northwind.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Dependency injection.
            var container = new UnityContainer();
            var datastoreConfig = new DatastoreConfig();
            var jwtManager = new JwtManager();
            // Read from config file.
            datastoreConfig.ConnectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"].ConnectionString;
            jwtManager.SetSecret(ConfigurationManager.AppSettings["jwtSecret"]);
            // Register instances.
            container.RegisterInstance<IDatastoreConfig>(datastoreConfig);
            container.RegisterInstance<IJwtManager>(jwtManager);
            // Register types.
            container.RegisterType<ICustomerOrdersDatastore, CustomerOrdersDatastore>();
            config.DependencyResolver = new DatastoreResolver(container);
            // Create a JwtAuthentication attribute.
            config.Filters.Add(new AuthorizeAttribute());
            // Allow attributes to override routes
            config.MapHttpAttributeRoutes();
            // Setup default API route template.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // XML is a sin.
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes
                .FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            // Swagger API documentation
            config
                .EnableSwagger(c =>
                {
                    c.IncludeXmlComments(string.Format(@"{0}\bin\Northwind.API.XML",
                        System.AppDomain.CurrentDomain.BaseDirectory));
                    c.SingleApiVersion("v1", "Northwind API");
                })
                .EnableSwaggerUi();
        }
    }
}
