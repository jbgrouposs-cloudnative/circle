using System.Web.Http;
using Owin;
using Unity.WebApi;
using Microsoft.Practices.Unity;
using Circle.Repositories.Article;
using Circle.Repositories.Comment;

namespace Circle.WebAPI {
    public static class Startup {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder) {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            var container = new UnityContainer();
            container.RegisterType<IArticleRepository, ArticleRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);

            appBuilder.UseWebApi(config);
        }
    }
}