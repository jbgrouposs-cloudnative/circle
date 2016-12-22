using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Interfaces
{
    /// <summary>
    /// フィード情報
    /// </summary>
    public class ArticleData
    {
        /// <summary>
        /// フィード管理ID
        /// </summary>
        public string FeedID { get; set; }

        /// <summary>
        /// フィードタグ配列
        /// 5つまで設定可能
        /// </summary>
        public string[] FeedTags { get; set; }

        /// <summary>
        /// フィードタイトル
        /// </summary>
        public string FeedTitle { get; set; }

        /// <summary>
        /// フィード本文
        /// </summary>
        public string FeedBody { get; set; }

        /// <summary>
        /// フィード投稿者ID
        /// </summary>
        public string PostUserID { get; set; }

        /// <summary>
        /// フィード投稿日時
        /// </summary>
        public DateTime PostDateTime { get; set; }

        /// <summary>
        /// フィード更新者ID
        /// </summary>
        public string UpdateUserID { get; set; }

        /// <summary>
        /// フィード更新日時
        /// </summary>
        public DateTime UpdateDateTime { get; set; }

        /// <summary>
        /// いいね数
        /// </summary>
        public int FavNum { get; set; }

        /// <summary>
        /// コメント数
        /// </summary>
        public int CommentNum { get; set; }

        /// <summary>
        /// 投稿方法区分
        /// 0:通常投稿 1:下書投稿 2:限定共有投稿(投稿者本人及びURLを知っているユーザーのみ閲覧可)
        /// </summary>
        public int PostType { get; set; }

        /// <summary>
        /// 新着フィードフラグ
        /// </summary>
        public Boolean NewFeedFlag { get; set; }
    }
}