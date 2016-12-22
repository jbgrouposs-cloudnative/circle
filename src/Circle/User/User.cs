using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Actors.Client;
using User.Interfaces;

using System;
using System.Security.Cryptography;
using System.Text;

namespace User
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
    internal class User : Actor, IUser
    {
        /// <summary>
        /// Initializes a new instance of User
        /// </summary>
        /// <param name="actorService">The Microsoft.ServiceFabric.Actors.Runtime.ActorService that will host this actor instance.</param>
        /// <param name="actorId">The Microsoft.ServiceFabric.Actors.ActorId for this actor instance.</param>
        public User(ActorService actorService, ActorId actorId)
            : base(actorService, actorId)
        {
        }

        public async Task<UserProperties> Login(string id, string password)
        {
            var p = await this.GetProperties();
            var hashedPassword = p.HashedPassword;


            // passwordをUTF-8エンコードでバイト配列化
            byte[] byteValue = Encoding.UTF8.GetBytes(password);

            // SHA1のハッシュ値を取得する
            SHA1 crypto = new SHA1CryptoServiceProvider();
            byte[] hashValue = crypto.ComputeHash(byteValue);

            // バイト配列をUTF8エンコードで文字列化
            StringBuilder hashedText = new StringBuilder();
            for (int i = 0; i < hashValue.Length; i++)
            {
                hashedText.AppendFormat("{0:X2}", hashValue[i]);
            }
            String diffPass = hashedText.ToString();
            Console.WriteLine("hashed text: " + diffPass);

            if (hashedPassword.Equals(diffPass))
            {
                return p;

            }
            return null;
        }

        public async Task<UserProperties> GetProperties()
        {
            return await this.StateManager.GetOrAddStateAsync(typeof(UserProperties).FullName, (UserProperties)null);
        }

        public async Task SetProperties(UserProperties properties)
        {
            await this.StateManager.SetStateAsync(typeof(UserProperties).FullName, properties);
        }


        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");

            // The StateManager is this actor's private state store.
            // Data stored in the StateManager will be replicated for high-availability for actors that use volatile or persisted state storage.
            // Any serializable object can be saved in the StateManager.
            // For more information, see https://aka.ms/servicefabricactorsstateserialization

            return this.StateManager.TryAddStateAsync("count", 0);
        }
    }
}
