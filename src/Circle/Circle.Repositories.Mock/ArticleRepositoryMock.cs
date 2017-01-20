using Circle.Repositories.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Mock {
    public class ArticleRepositoryMock : IArticleRepository {
        public void Dispose() {
        }

        public ArticleData GetArticle(string articleId) {
            return new ArticleData() {
                AuthorName = "高木俊一",
                Body = "本文",
                Created = DateTime.Now,
                Id = articleId,
                Title = "タイトル",
                Updated = DateTime.Now
            };
        }

        public List<ArticleData> GetArticles() {
            return new List<ArticleData>() {
                GetArticle(Guid.NewGuid().ToString()),
                GetArticle(Guid.NewGuid().ToString()),
                GetArticle(Guid.NewGuid().ToString())
            };
        }

        public Task<ArticleData> SaveArticle(ArticleData article) {
            return Task.Run<ArticleData>(() => article);
        }
    }
}