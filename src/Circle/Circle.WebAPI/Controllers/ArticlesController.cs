using Circle.Repositories.Article;
using Circle.Repositories.Comment;
using Circle.WebAPI.Models;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Circle.WebAPI.Controllers {

    [ServiceRequestActionFilter]
    [RoutePrefix("api")]
    public class ArticlesController : ApiController {
        private IArticleRepository articleRepository;
        private ICommentRepository commentRepository;

        public ArticlesController(IArticleRepository articleRepository, ICommentRepository commentRepository) {
            this.articleRepository = articleRepository;
            this.commentRepository = commentRepository;
        }

        /// <summary>
        /// 記事一覧の取得
        /// </summary>
        /// <returns></returns>
        [Route("articles")]
        public List<ArticleData> GetArticles() {
            try
            {
                var article = articleRepository.GetArticles();
                return article;
            }
            catch (Exception)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 記事詳細の取得
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("articles/{articleId}")]
        public ArticleData GetArticle(string articleId) {
            try {
                var article = articleRepository.GetArticle(articleId);
                return article;
            }
            catch( Exception ) {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 記事投稿
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [Route("articles")]
        public async Task<ArticleData> PostArticle(ArticleData article) {
            try {
                var savedArticle = await articleRepository.SaveArticle(article);
                return savedArticle;
            }
            catch( Exception ) {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 記事のコメント一覧取得
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("articles/{articleId}/comments")]
        public List<CommentData> GetCommentsByArticle(string articleId) {
            try {
                var comments = commentRepository.GetComments(articleId);
                return comments;
            }
            catch( Exception ) {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// コメント投稿
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("articles/{articleId}/comments")]
        public async Task<CommentData> PostComment(string articleId, CommentData comment) {
            try {
                if( comment.ArticleId == null ) {
                    comment.ArticleId = articleId;
                }
                else if( comment.ArticleId != articleId ) {
                    // POSTデータの中に書いてあるarticleIdとURLで指定されたarticleIdが一致していない場合、BadRequestでエラーにする
                    throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
                }

                return await commentRepository.SaveComment(comment);
            }
            catch( Exception ) {
                throw new HttpResponseException(System.Net.HttpStatusCode.InternalServerError);
            }
        }


        public new void Dispose() {
            articleRepository.Dispose();
            commentRepository.Dispose();
            base.Dispose();
        }
    }
}