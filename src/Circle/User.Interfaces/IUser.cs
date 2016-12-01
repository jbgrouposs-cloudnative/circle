using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Article.Interfaces;

namespace User.Interfaces
{
    /// <summary>
    /// ユーザ関連を処理するアクター
    /// </summary>
    public interface IUser : IActor
    {
        /// <summary>
        /// ユーザ情報を取得する
        /// </summary>
        /// <returns></returns>
        Task<UserData> GetData();

        /// <summary>
        /// ユーザ情報を保存する
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task Save(UserData data);

        /// <summary>
        /// 下書きフィード情報の一覧を取得する
        /// </summary>
        /// <returns></returns>
        Task<ArticleDataDraftList> GetDraftArticles();
        
        /// <summary>
        /// 投稿済みフィード情報の一覧を取得する
        /// </summary>
        /// <returns></returns>
        Task<ArticleDataPublishedList> GetPublishedArticles();

        /// <summary>
        /// ストックしたフィード情報の一覧を取得する
        /// </summary>
        /// <returns></returns>
        Task<ArticleDataStockedList> GetStockedArticles();

        /// <summary>
        /// フィードを下書き保存する
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        Task SaveDraft(IArticle article);

        /// <summary>
        /// フィードを投稿する
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        Task Publish(IArticle article);

        /// <summary>
        /// フィードをストックする
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        Task Stock(IArticle article);
    }
}
