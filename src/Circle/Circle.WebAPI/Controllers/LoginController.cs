using Circle.Repositories.User;
using Circle.WebAPI.Models;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using User.Interfaces;

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
        public async Task<ResponseData<LoginResponse>> Post([FromBody]LoginRequest req)
        {
            var repo = new UserRepository();
            var user = repo.FindById(req.Id); // IDからユーザのアクターを探す

            if (user != null)
            {
                //　Userアクターが見つかったら認証処理を呼び出す
                UserProperties userProperties = await user.Login(req.Id, req.Password);

                if (userProperties != null)
                {
                    // 認証に成功したらトークンを返す
                    return ResponseData<LoginResponse>.BuildOK(new LoginResponse()
                    {
                        AccessToken = userProperties.Token
                    });
                }
            }

            // 認証失敗
            return ResponseData<LoginResponse>.Build("600", "Login Failure");
        }
    }

    public class LoginRequest
    {
        /// <summary>
        /// 認証ユーザID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 認証パスワード
        /// </summary>
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        /// <summary>
        /// 認証トークン
        /// </summary>
        public string AccessToken { get; set; }
    }
}