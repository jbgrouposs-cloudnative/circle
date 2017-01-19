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
        public int Id { get; set; }

        /// <summary>
        /// 記事タイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 記事本文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 著者名
        /// </summary>
        public string AuthorName { get; set; }

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
