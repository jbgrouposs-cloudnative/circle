using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Article {
    public class ArticleRepository : IArticleRepository {

        // DocumentDBクライアント
        private static readonly string databaseId = ConfigurationManager.AppSettings["DatabaseId"];
        private static readonly string collectionId = "ArticleData";
        private DocumentClient client;

        public ArticleRepository() {
            this.client = DocumentDBResolver.GetClient(); // DocumentDBクライアントを取得
        }

        public ArticleData GetArticle(int articleId) {
            throw new NotImplementedException();
        }

        public List<ArticleData> GetArticles() {
            throw new NotImplementedException();
        }

        public async Task<ArticleData> SaveArticle(ArticleData article)
        {
            throw new NotImplementedException();

            Uri collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
            Document created = await client.CreateDocumentAsync(collectionLink, article);

            return article;

        }

        public void Dispose() {
            client.Dispose(); // DocumentDBへの接続を破棄
        }
    }
}