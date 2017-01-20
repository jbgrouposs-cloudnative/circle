using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Article {
    public interface IArticleRepository : IDisposable {

        /// <summary>
        /// 記事一覧を取得する
        /// </summary>
        /// <returns></returns>
        List<ArticleData> GetArticles();

        /// <summary>
        /// 指定した記事を取得する
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        ArticleData GetArticle(string articleId);

        /// <summary>
        /// 記事を保存する
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        Task<ArticleData> SaveArticle(ArticleData article);
    }
}