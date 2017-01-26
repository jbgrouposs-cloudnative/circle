using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
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
            return this.client.CreateDocumentQuery<CommentData>(GetDocumentCollectionUri())
                .Where(document => document.ArticleId == articleId)
                .AsEnumerable()
                .ToList<CommentData>();
        }

        public async Task<CommentData> SaveComment(CommentData comment) {
            var response = await client.CreateDocumentAsync(GetDocumentCollectionUri(), comment);
            var savedComment = JsonConvert.DeserializeObject<CommentData>(response.Resource.ToString());

            return savedComment;
        }

        public void Dispose() {
            client.Dispose(); // DocumentDBへの接続を破棄
        }

        private Uri GetDocumentCollectionUri() {
            return UriFactory.CreateDocumentCollectionUri(this.dbname, this.colname);
        }
    }
}