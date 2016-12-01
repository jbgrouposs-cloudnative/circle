using Article.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Interfaces
{
    /// <summary>
    /// 投稿済みフィード情報の一覧
    /// </summary>
    public class ArticleDataPublishedList
    {
        /// <summary>
        /// フィード情報の一覧
        /// </summary>
        public List<ArticleData> Articles { get; set; }
    }
}
