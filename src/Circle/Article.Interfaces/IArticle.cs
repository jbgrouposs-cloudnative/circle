using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Article.Interfaces
{
    /// <summary>
    /// 記事関連のデータを処理するアクター
    /// </summary>
    public interface IArticle : IActor
    {
        /// <summary>
        /// 記事データを取得する
        /// </summary>
        /// <returns></returns>
        Task<ArticleData> GetData();

        /// <summary>
        /// 記事データを保存する
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task Save(ArticleData data);

        /// <summary>
        /// 記事に対するコメント一覧を取得する
        /// </summary>
        /// <returns></returns>
        Task<CommentDataList> GetCommentDataList();

        /// <summary>
        /// コメントを追加する
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task AddComment(CommentData comment);
    }
}