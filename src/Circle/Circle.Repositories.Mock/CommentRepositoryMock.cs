using Circle.Repositories.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Mock {
    public class CommentRepositoryMock : ICommentRepository {
        public void Dispose() {
        }

        public List<CommentData> GetComments(string articleId) {
            return new List<CommentData>() {
                new CommentData() { Body ="コメント本文", Created = DateTime.Now, Id = Guid.NewGuid().ToString(), OwnerName = "高木俊一", Updated = DateTime.Now },
                new CommentData() { Body ="コメント本文", Created = DateTime.Now, Id = Guid.NewGuid().ToString(), OwnerName = "高木俊一", Updated = DateTime.Now },
                new CommentData() { Body ="コメント本文", Created = DateTime.Now, Id = Guid.NewGuid().ToString(), OwnerName = "高木俊一", Updated = DateTime.Now }
            };
        }

        public CommentData SaveComment(string articleId, CommentData comment) {
            return comment;
        }
    }
}