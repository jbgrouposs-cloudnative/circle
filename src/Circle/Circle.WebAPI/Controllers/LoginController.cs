using Article.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Circle.WebAPI.Controllers
{
    [ServiceRequestActionFilter]
    public class LoginController : ApiController
    {   
        // POST https://restapi.example.com/login HTTP/1.1
        // Host: restapi.example.com
        // User-Agent: RESTfulAPI-Client
        //
        // { "id" : "user@example.com", "password" : "passw0rd" }
        public int Post(string id, string password)
        {
            return 200;
        }
    }
}