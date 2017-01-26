using Newtonsoft.Json;
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
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// コメント対象の記事ID
        /// </summary>
        [JsonProperty("article_id")]
        public string ArticleId { get; set; }

        /// <summary>
        /// コメント本文
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// コメント投稿者名
        /// </summary>
        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }
    }
}
