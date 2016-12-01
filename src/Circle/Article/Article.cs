using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;
using Article.Interfaces;

namespace Article
{
    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    internal class Article : Actor, IArticle
    {
        /// <summary>
        /// Initializes a new instance of Article
        /// </summary>
        /// <param name="actorService">The Microsoft.ServiceFabric.Actors.Runtime.ActorService that will host this actor instance.</param>
        /// <param name="actorId">The Microsoft.ServiceFabric.Actors.ActorId for this actor instance.</param>
        public Article(ActorService actorService, ActorId actorId)
            : base(actorService, actorId)
        {
        }

        public async Task AddComment(CommentData comment)
        {
            var commentList = await this.GetCommentDataList();
            commentList.Comments.Add(comment);

            await this.StateManager.SetStateAsync(typeof(CommentDataList).FullName, commentList);
        }

        public async Task<CommentDataList> GetCommentDataList()
        {
            return await this.StateManager.GetOrAddStateAsync(typeof(CommentDataList).FullName, new CommentDataList());
        }

        public async Task<ArticleData> GetData()
        {
            return await this.StateManager.GetOrAddStateAsync(typeof(ArticleData).FullName, new ArticleData());
        }

        public async Task Save(ArticleData data)
        {
            await this.StateManager.SetStateAsync(typeof(ArticleData).FullName, data);
        }
    }
}