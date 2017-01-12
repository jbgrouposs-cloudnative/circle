using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Comment {
    public class CommentRepository : ICommentRepository {
        public List<CommentData> GetComments(int articleId) {
            throw new NotImplementedException();
        }

        public CommentData SaveComment(int articleId, CommentData comment) {
            throw new NotImplementedException();
        }
    }
}
