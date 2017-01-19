using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circle.WebAPI.Controllers;
using Circle.Repositories.Article;
using Circle.Repositories.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.WebAPI.Controllers.Tests {
    [TestClass()]
    public class ArticlesControllerTests {

        [TestMethod]
        public void GetArticles() {

            using( var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository()) ) {
                try {
                    var r = articlesController.GetArticles();

                    Assert.IsNotNull(r);
                }
                catch(Exception e) {
                    Assert.Fail(e.Message, e);
                }
            }
        }

        [TestMethod]
        public void GetArticle() {
            var articleId = 1;

            using( var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository()) ) {
                try {
                    var r = articlesController.GetArticle(articleId);

                    Assert.IsNotNull(r);
                    Assert.AreEqual(articleId, r.Id);
                }
                catch( Exception e ) {
                    Assert.Fail(e.Message, e);
                }
            }
        }

        [TestMethod]
        public void GetCommentsByArticle() {
            var articleId = 1;

            using( var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository()) ) {
                try {
                    var r = articlesController.GetCommentsByArticle(articleId);

                    Assert.IsNotNull(r);

                }
                catch( Exception e ) {
                    Assert.Fail(e.Message, e);
                }
            }
        }


        [TestMethod]
        public void SaveArticle() {

            using( var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository()) ) {
                try {
                    var r1 = articlesController.PostArticle(new ArticleData() {
                        AuthorName = "高木俊一",
                        Body = "記事本文",
                        Created = DateTime.Now,
                        Title = "記事タイトル",
                        Updated = DateTime.Now
                    });

                    Assert.IsNotNull(r1);
                    Assert.AreEqual("高木俊一", r1.AuthorName);
                    Assert.AreEqual("記事本文", r1.Body);
                    Assert.AreEqual("記事タイトル", r1.Title);

                }
                catch( Exception e ) {
                    Assert.Fail(e.Message, e);
                }
            }
        }

        [TestMethod]
        public void SaveArticleAndGet() {

            using( var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository()) ) {
                try {
                    var r1 = articlesController.PostArticle(new ArticleData() {
                        AuthorName = "高木俊一",
                        Body = "記事本文",
                        Created = DateTime.Now,
                        Title = "記事タイトル",
                        Updated = DateTime.Now
                    });

                    var r2 = articlesController.GetArticle(r1.Id);


                    Assert.IsNotNull(r2);
                    Assert.AreEqual("高木俊一", r2.AuthorName);
                    Assert.AreEqual("記事本文", r2.Body);
                    Assert.AreEqual("記事タイトル", r2.Title);

                }
                catch( Exception e ) {
                    Assert.Fail(e.Message, e);
                }
            }
        }

        [TestMethod]
        public void SaveArticleAndGetAll() {

            using( var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository()) ) {
                try {
                    var r1 = articlesController.PostArticle(new ArticleData() {
                        AuthorName = "高木俊一",
                        Body = "記事本文",
                        Created = DateTime.Now,
                        Title = "記事タイトル",
                        Updated = DateTime.Now
                    });

                    var r2 = articlesController.GetArticles();

                    Assert.IsNotNull(r2);

                    var article = r2.Where(a => a.Id == r1.Id).SingleOrDefault();

                    Assert.IsNotNull(article);
                    Assert.AreEqual("高木俊一", article.AuthorName);
                    Assert.AreEqual("記事本文", article.Body);
                    Assert.AreEqual("記事タイトル", article.Title);

                }
                catch( Exception e ) {
                    Assert.Fail(e.Message, e);
                }
            }
        }

        [TestMethod]
        public void SaveComment() {

            using( var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository()) ) {
                try {
                    var r1 = articlesController.PostArticle(new ArticleData());
                    var r2 = articlesController.PostComment(r1.Id, new CommentData() {
                        Body = "コメント本文",
                        Created = DateTime.Now,
                        OwnerName = "高木俊一",
                        Updated = DateTime.Now
                    });

                    Assert.IsNotNull(r2);
                    Assert.AreEqual("コメント本文", r2.Body);
                    Assert.AreEqual("高木俊一", r2.OwnerName);

                }
                catch( Exception e ) {
                    Assert.Fail(e.Message, e);
                }
            }
        }

        [TestMethod]
        public void SaveCommentAndGetAll() {

            using( var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository()) ) {
                var r1 = articlesController.PostArticle(new ArticleData());
                var r2 = articlesController.PostComment(r1.Id, new CommentData() {
                    Body = "コメント本文",
                    Created = DateTime.Now,
                    OwnerName = "高木俊一",
                    Updated = DateTime.Now
                });

                Assert.IsNotNull(r2);

                var r3 = articlesController.GetCommentsByArticle(r1.Id);
                var comment = r3.Where(c => c.Id == r2.Id).SingleOrDefault();

                Assert.IsNotNull(comment);
                Assert.AreEqual("コメント本文", comment.Body);
                Assert.AreEqual("高木俊一", comment.OwnerName);
            }
        }
    }
}