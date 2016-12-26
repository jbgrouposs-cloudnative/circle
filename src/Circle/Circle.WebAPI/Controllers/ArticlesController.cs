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

            return await article.GetData();
        }

        // POST api/articles?title=abc&body=aaaaaaaaaaaa
        public async Task Post(string title, string body)
        {
            // POSTされたデータから新しいArticleアクターを作成する
            var actorId = ActorId.CreateRandom();
            var article = ActorProxy.Create<IArticle>(actorId, "fabric:/Circle");

            await article.Save(new ArticleData()
            {
                //フィード管理ID(アクターID)
                FeedID = actorId.ToString(),
                //フィード登録タグ配列
                FeedTags = new string[5] { "TestTag1", "TestTag2", "TestTag3", "TestTag4", "TestTag5" },
                //フィードタイトル
                FeedTitle = title,
                //フィード本文
                FeedBody = body,
                //フィード投稿者ID
                PostUserID = "TestDummyUser",
                //フィード投稿日時
                PostDateTime = DateTime.UtcNow,
                //フィード更新者ID
                UpdateUserID = null,
                //フィード更新日時
                UpdateDateTime = DateTime.MinValue,
                //いいね数、どう取得するか要検討
                FavNum = 0,
                //コメント数、どう取得するか要検討
                CommentNum = 0,
                //投稿方法区分(0:通常投稿 1:下書投稿 2:限定共有投稿)
                PostType = 0,
                //新着フィードフラグ
                NewFeedFlag = true
            });
        }
    }
}