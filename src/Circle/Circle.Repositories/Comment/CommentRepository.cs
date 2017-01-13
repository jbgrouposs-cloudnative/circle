using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories.Comment {
    public class CommentRepository : ICommentRepository {

        // DocumentDBクライアント
        private DocumentClient client;

        public CommentRepository() {
            this.client = DocumentDBResolver.GetClient(); // DocumentDBクライアントを取得
        }

        public List<CommentData> GetComments(int articleId) {
            throw new NotImplementedException();
        }

        public CommentData SaveComment(int articleId, CommentData comment) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            client.Dispose(); // DocumentDBへの接続を破棄
        }
    }
}