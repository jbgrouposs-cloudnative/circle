using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circle.WebAPI.Controllers;
using Circle.Repositories.Article;
using Circle.Repositories.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle.Repositories.Mock;

namespace Circle.WebAPI.Controllers.Tests {
    [TestClass()]
    public class ArticlesControllerTests {

        private ArticlesController GetArticlesController() {
            return new ArticlesController(new ArticleRepository(), new CommentRepository());
            //return new ArticlesController(new ArticleRepositoryMock(), new CommentRepositoryMock());
        }

        [TestMethod]
        public void GetArticles() {

            using( var articlesController = GetArticlesController() ) {
                try {
                    var r = articlesController.GetArticles();

                    Assert.IsNotNull(r);
                }
                catch( Exception e ) {
                    Assert.Fail(e.Message, e);
                }
            }
        }

        [TestMethod]
        public void GetArticle() {
            var articleId = "2c3322a2-e85b-498f-9773-d420e6b4c064";

            using( var articlesController = GetArticlesController() ) {
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
            var articleId = "2c3322a2-e85b-498f-9773-d420e6b4c064";

            using ( var articlesController = GetArticlesController() ) {
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
            Task.Run(async () => {
                using( var articlesController = GetArticlesController() ) {
                    try {
                        var date = DateTime.Now;
                        var r1 = await articlesController.PostArticle(new ArticleData() {
                            AuthorName = "高木俊一",
                            Body = "記事本文",
                            Created = date,
                            Title = "記事タイトル",
                            Updated = date
                        });

                        Assert.IsNotNull(r1);
                        Assert.AreEqual("高木俊一", r1.AuthorName);
                        Assert.AreEqual("記事本文", r1.Body);
                        Assert.AreEqual(date, r1.Created);
                        Assert.AreEqual("記事タイトル", r1.Title);
                        Assert.AreEqual(date, r1.Updated);

                    }
                    catch( Exception e ) {
                        Assert.Fail(e.Message, e);
                    }
                }
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void SaveArticleAndGet() {

            Task.Run(async () => {
                using( var articlesController = GetArticlesController() ) {
                    try {
                        var r1 = await articlesController.PostArticle(new ArticleData() {
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
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void SaveArticleAndGetAll() {

            Task.Run(async () => {
                using( var articlesController = GetArticlesController() ) {
                    try {
                        var r1 = await articlesController.PostArticle(new ArticleData() {
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
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void SaveComment() {

            Task.Run(async () => {
                using( var articlesController = GetArticlesController() ) {
                    try {
                        var r1 = await articlesController.PostArticle(new ArticleData());
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
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void SaveCommentAndGetAll() {

            Task.Run(async () => {
                using( var articlesController = GetArticlesController() ) {
                    var r1 = await articlesController.PostArticle(new ArticleData());
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
            }).GetAwaiter().GetResult();
        }
    }
}