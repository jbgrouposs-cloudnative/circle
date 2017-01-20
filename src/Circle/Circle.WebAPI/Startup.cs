using System.Web.Http;
using Owin;
using Unity.WebApi;
using Microsoft.Practices.Unity;
using Circle.Repositories.Article;
using Circle.Repositories.Comment;
using Swashbuckle.Application;
using System.Configuration;
using Circle.Repositories.Mock;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Dependencies;

namespace Circle.WebAPI {
    public static class Startup {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder) {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = ConfigureDependencyResolver();

            config.EnableSwagger(c => c.SingleApiVersion("v1", "Circle.WebAPI")).EnableSwaggerUi();
            

            appBuilder.UseWebApi(config);
        }

        private static IDependencyResolver ConfigureDependencyResolver() {
            var container = new UnityContainer();

            var mockConfig = ConfigurationManager.AppSettings["Mock"];
            bool mock;
            if( bool.TryParse(mockConfig, out mock) && mock ) {
                container.RegisterType<IArticleRepository, ArticleRepositoryMock>(new HierarchicalLifetimeManager());
                container.RegisterType<ICommentRepository, CommentRepositoryMock>(new HierarchicalLifetimeManager());

                return new UnityDependencyResolver(container);
            }

            container.RegisterType<IArticleRepository, ArticleRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());

            return new UnityDependencyResolver(container);
        }
    }
}