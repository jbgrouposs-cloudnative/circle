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
        // DocumentDB DB名
        private string dbname = "CircleDB";
        // DocumentDB コレクション名
        private string colname = "Comments";


        public CommentRepository() {
            this.client = DocumentDBResolver.GetClient(); // DocumentDBクライアントを取得
        }

        public List<CommentData> GetComments(string articleId) {
            throw new NotImplementedException();
        }

        public CommentData SaveComment(string articleId, CommentData comment) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            client.Dispose(); // DocumentDBへの接続を破棄
        }
    }
}