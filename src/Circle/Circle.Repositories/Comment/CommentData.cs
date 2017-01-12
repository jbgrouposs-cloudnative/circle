using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Comment {
    
    /// <summary>
    /// コメント
    /// </summary>
    public class CommentData {

        /// <summary>
        /// コメントID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// コメント本文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// コメント投稿者名
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime Updated { get; set; }
    }
}
