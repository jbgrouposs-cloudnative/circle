using Circle.Repositories.Article;
using Circle.Repositories.Comment;
using Circle.WebAPI.Models;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Circle.WebAPI.Controllers {
    [ServiceRequestActionFilter]
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
        [Route("api/articles")]
        public ResponseData<List<ArticleData>> GetArticles() {
            try {
                var articles = articleRepository.GetArticles();
                return ResponseData<List<ArticleData>>.BuildOK(articles);
            }
            catch( Exception e ) {
                return ResponseData<List<ArticleData>>.BuildUnknownError(e.Message);
            }
        }

        /// <summary>
        /// 記事詳細の取得
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("api/articles/{articleId:int}")]
        public ResponseData<ArticleData> GetArticle(int articleId) {
            try {
                var article = articleRepository.GetArticle(articleId);
                return ResponseData<ArticleData>.BuildOK(article);
            }
            catch( Exception e ) {
                return ResponseData<ArticleData>.BuildUnknownError(e.Message);
            }
        }

        /// <summary>
        /// 記事投稿
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [Route("api/articles")]
        public ResponseData<ArticleData> PostArticle(ArticleData article) {
            try {
                var savedArticle = articleRepository.SaveArticle(article);
                return ResponseData<ArticleData>.BuildOK(savedArticle);
            }
            catch( Exception e ) {
                return ResponseData<ArticleData>.BuildUnknownError(e.Message);
            }
        }

        /// <summary>
        /// 記事のコメント一覧取得
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("api/articles/{articleId:int}/comments")]
        public ResponseData<List<CommentData>> GetCommentsByArticle(int articleId) {
            try {
                var comments = commentRepository.GetComments(articleId);
                return ResponseData<List<CommentData>>.BuildOK(comments);
            }
            catch( Exception e ) {
                return ResponseData<List<CommentData>>.BuildUnknownError(e.Message);
            }
        }

        /// <summary>
        /// コメント投稿
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        [Route("api/articles/{articleId:int}/comments")]
        public ResponseData<CommentData> PostComment(int articleId, CommentData comment) {
            try {
                var savedComment = commentRepository.SaveComment(articleId, comment);
                return ResponseData<CommentData>.BuildOK(savedComment);
            }
            catch( Exception e ) {
                return ResponseData<CommentData>.BuildUnknownError(e.Message);
            }
        }
    }
}