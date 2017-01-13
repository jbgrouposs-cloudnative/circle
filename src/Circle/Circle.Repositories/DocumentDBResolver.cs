using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Repositories {
    public class DocumentDBResolver {

        public static DocumentClient GetClient() {
            var endpointUri = ConfigurationManager.AppSettings["DocumentDB.EndpointUri"];
            var authorizationKey = ConfigurationManager.AppSettings["DocumentDB.AuthorizationKey"];

            return GetClient(endpointUri, authorizationKey);
        }

        public static DocumentClient GetClient(string endpointUri, string authorizationKey) {
            return new DocumentClient(new Uri(endpointUri), authorizationKey);
        }
    }
}