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
        /// 記事タイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 記事本文
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 記事公開日
        /// </summary>
        public DateTime Published { get; set; }
    }
}
