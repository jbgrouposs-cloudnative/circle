using Microsoft.Azure.Documents.Client;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Interfaces;

namespace Circle.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private static readonly string EndpointUrl = "https://localhost:8081";
        private static readonly string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private static readonly string DatabaseName = "Circle";
        private static readonly string CollectionName = "User";

        private DocumentClient client;

        public UserRepository()
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);
        }

        public IUser FindById(string id)
        {
            var uri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
            var q = from p in this.client.CreateDocumentQuery<UserProperties>(uri)
                    where p.Id == id
                    select p;

            var properties = q.FirstOrDefault();
            var user = ActorProxy.Create<IUser>(new ActorId(properties.ActorId), "fabric:/Circle");

            return user;
        }

        public async Task<IUser> CreateAsync(UserProperties properties)
        {
            var user = this.FindById(properties.Id);
            if (user == null)
            {
                var actorId = ActorId.CreateRandom();
                user = ActorProxy.Create<IUser>(actorId, "fabric:/Circle");
                properties.ActorId = user.GetActorId().GetStringId();

                await user.SetProperties(properties);
            }

            return user;
        }
    }
}