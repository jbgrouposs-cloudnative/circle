using Article.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Circle.WebAPI.Controllers
{
    [ServiceRequestActionFilter]
    public class ArticlesController : ApiController
    {
        // GET api/articles/5 
        public async Task<ArticleData> Get(int id)
        {
            // Articleアクターの情報を返す
            var actorId = new ActorId("00000000-0000-0000-0000-000000000000");
            var article = ActorProxy.Create<IArticle>(actorId, "fabric:/Circle");

            return await article.Get();
        }

        // POST api/articles?title=abc&body=aaaaaaaaaaaa
        public async Task Post(string title, string body)
        {
            // POSTされたデータから新しいArticleアクターを作成する
            var actorId = new ActorId("00000000-0000-0000-0000-000000000000");
            var article = ActorProxy.Create<IArticle>(actorId, "fabric:/Circle");

            await article.Update(new ArticleData()
            {
                Title = title,
                Body = body,
                Published = DateTime.UtcNow
            });
        }
    }
}