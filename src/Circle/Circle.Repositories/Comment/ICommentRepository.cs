using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Comment {
    public interface ICommentRepository : IDisposable {
        /// <summary>
        /// 記事のコメントを取得する
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        List<CommentData> GetComments(string articleId);

        /// <summary>
        /// 記事にコメントを付ける
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        CommentData SaveComment(string articleId, CommentData comment);
    }
}
