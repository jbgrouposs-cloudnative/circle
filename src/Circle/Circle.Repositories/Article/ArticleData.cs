using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Article {

    /// <summary>
    /// 記事
    /// </summary>
    public class ArticleData {

        /// <summary>
        /// 記事ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 記事タイトル
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 記事本文
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// 著者名
        /// </summary>
        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

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
