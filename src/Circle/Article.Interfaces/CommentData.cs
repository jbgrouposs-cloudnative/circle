using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Interfaces
{
    /// <summary>
    /// コメント情報
    /// </summary>
    public class CommentData
    {
        /// <summary>
        /// フィード管理ID
        /// </summary>
        public string FeedID { get; set; }

        /// <summary>
        /// コメント管理ID
        /// </summary>
        public string CommentID { get; set; }

        /// <summary>
        /// コメント
        /// </summary>
        public string CommentBody { get; set; }

        /// <summary>
        /// コメント投稿者ID
        /// </summary>
        public string CommentUserID { get; set; }

        /// <summary>
        /// コメント投稿日時
        /// </summary>
        public DateTime CommPostDateTime { get; set; }

        /// <summary>
        /// コメント更新者ID
        /// </summary>
        public string CommUpdateUserID { get; set; }

        /// <summary>
        /// コメント更新日時
        /// </summary>
        public DateTime CommUpdateDateTime { get; set; }
    }
}
