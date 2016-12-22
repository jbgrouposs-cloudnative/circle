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
        //private static readonly string EndpointUrl = "https://localhost:8081";
        //private static readonly string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        //private DocumentClient client;

        public IUser FindById(string id)
        {
            return null;
        }
    }
}