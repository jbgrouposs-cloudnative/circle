using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Interfaces
{
    /// <summary>
    /// コメント情報の一覧
    /// </summary>
    public class CommentDataList
    {
        public List<CommentData> Comments { get; set; }
    }
}