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
            var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository());
            var r = articlesController.GetArticles();

            Assert.AreEqual("200", r.StatusCode);
            Assert.AreEqual("OK", r.StatusMessage);
        }

        [TestMethod]
        public void GetArticle() {
            var articleId = 1;
            var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository());
            var r = articlesController.GetArticle(articleId);

            Assert.AreEqual("200", r.StatusCode);
            Assert.AreEqual("OK", r.StatusMessage);
            Assert.AreEqual(articleId, r.Data.Id);
        }

        [TestMethod]
        public void GetCommentsByArticle() {
            var articleId = 1;
            var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository());
            var r = articlesController.GetCommentsByArticle(articleId);

            Assert.AreEqual("200", r.StatusCode);
            Assert.AreEqual("OK", r.StatusMessage);
        }


        [TestMethod]
        public void SaveArticle() {
            var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository());
            var r1 = articlesController.PostArticle(new ArticleData() {
                AuthorName = "高木俊一",
                Body = "記事本文",
                Created = DateTime.Now,
                Title = "記事タイトル",
                Updated = DateTime.Now
            });

            Assert.AreEqual("200", r1.StatusCode);
            Assert.AreEqual("OK", r1.StatusMessage);
            Assert.AreEqual("高木俊一", r1.Data.AuthorName);
            Assert.AreEqual("記事本文", r1.Data.Body);
            Assert.AreEqual("記事タイトル", r1.Data.Title);
        }
        
        [TestMethod]
        public void SaveArticleAndGet() {
            var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository());
            var r1 = articlesController.PostArticle(new ArticleData() {
                AuthorName = "高木俊一",
                Body = "記事本文",
                Created = DateTime.Now,
                Title = "記事タイトル",
                Updated = DateTime.Now
            });

            var r2 = articlesController.GetArticle(r1.Data.Id);

            Assert.AreEqual("200", r2.StatusCode);
            Assert.AreEqual("OK", r2.StatusMessage);
            Assert.AreEqual("高木俊一", r2.Data.AuthorName);
            Assert.AreEqual("記事本文", r2.Data.Body);
            Assert.AreEqual("記事タイトル", r2.Data.Title);
        }

        [TestMethod]
        public void SaveArticleAndGetAll() {
            var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository());
            var r1 = articlesController.PostArticle(new ArticleData() {
                AuthorName = "高木俊一",
                Body = "記事本文",
                Created = DateTime.Now,
                Title = "記事タイトル",
                Updated = DateTime.Now
            });

            var r2 = articlesController.GetArticles();

            Assert.AreEqual("200", r2.StatusCode);
            Assert.AreEqual("OK", r2.StatusMessage);

            var article = r2.Data.Where(a => a.Id == r1.Data.Id).SingleOrDefault();

            Assert.IsNotNull(article);
            Assert.AreEqual("高木俊一", article.AuthorName);
            Assert.AreEqual("記事本文", article.Body);
            Assert.AreEqual("記事タイトル", article.Title);
        }

        [TestMethod]
        public void SaveComment() {
            var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository());
            var r1 = articlesController.PostArticle(new ArticleData());

            var r2 = articlesController.PostComment(r1.Data.Id, new CommentData() {
                Body = "コメント本文",
                Created = DateTime.Now,
                OwnerName = "高木俊一",
                Updated = DateTime.Now
            });
            
            Assert.AreEqual("200", r2.StatusCode);
            Assert.AreEqual("OK", r2.StatusMessage);
            Assert.AreEqual("コメント本文", r2.Data.Body);
            Assert.AreEqual("高木俊一", r2.Data.OwnerName);
        }

        [TestMethod]
        public void SaveCommentAndGetAll() {
            var articlesController = new ArticlesController(new ArticleRepository(), new CommentRepository());
            var r1 = articlesController.PostArticle(new ArticleData());
            var r2 = articlesController.PostComment(r1.Data.Id, new CommentData() {
                Body = "コメント本文",
                Created = DateTime.Now,
                OwnerName = "高木俊一",
                Updated = DateTime.Now
            });

            Assert.AreEqual("200", r2.StatusCode);
            Assert.AreEqual("OK", r2.StatusMessage);

            var r3 = articlesController.GetCommentsByArticle(r1.Data.Id);
            var comment = r3.Data.Where(c => c.Id == r2.Data.Id).SingleOrDefault();

            Assert.IsNotNull(comment);
            Assert.AreEqual("コメント本文", comment.Body);
            Assert.AreEqual("高木俊一", comment.OwnerName);
        }
    }
}