﻿using Microsoft.Azure.Documents;
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
        // DocumentDB DB名
        private string dbname = "CircleDB";
        // DocumentDB コレクション名
        private string colname = "Articles";

        public ArticleRepository() {
            this.client = DocumentDBResolver.GetClient(); // DocumentDBクライアントを取得
        }

        public ArticleData GetArticle(int articleId) {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IQueryable<ArticleData> articleQuery = this.client.CreateDocumentQuery<ArticleData>(
                UriFactory.CreateDocumentCollectionUri(this.dbname, this.colname), queryOptions).Where(f => f.Id == articleId
                );
            return articleQuery.SingleOrDefault();
            // throw new NotImplementedException();
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