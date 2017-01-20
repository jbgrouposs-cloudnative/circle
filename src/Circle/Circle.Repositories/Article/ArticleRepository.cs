using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Article {
    public class ArticleRepository : IArticleRepository {

        // DocumentDBクライアント
        private DocumentClient client;
        // DocumentDB DB名
        private string dbname = "CircleDB";
        // DocumentDB コレクション名
        private string colname = "Articles";

        public ArticleRepository() {
            this.client = DocumentDBResolver.GetClient(); // DocumentDBクライアントを取得
        }

        public ArticleData GetArticle(string articleId)
        {
            return this.client.CreateDocumentQuery<ArticleData>(
               UriFactory.CreateDocumentCollectionUri(this.dbname, this.colname)
               ).Where(document => document.Id == articleId).AsEnumerable().SingleOrDefault();
            
            throw new NotImplementedException();
        }

        public List<ArticleData> GetArticles() {
            throw new NotImplementedException();
        }

        public async Task<ArticleData> SaveArticle(ArticleData article)
        {
            Uri collectionLink = UriFactory.CreateDocumentCollectionUri(this.dbname, this.colname);
            var response = await client.CreateDocumentAsync(collectionLink, article);

            return JsonConvert.DeserializeObject<ArticleData>(response.Resource.ToString());
        }

        public void Dispose() {
            client.Dispose(); // DocumentDBへの接続を破棄
        }
    }
}