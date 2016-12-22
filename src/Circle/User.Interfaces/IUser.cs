using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Article.Interfaces;

namespace User.Interfaces
{
    /// <summary>
    /// ユーザ関連を処理するアクター
    /// </summary>
    public interface IUser : IActor
    {
        /// <summary>
        /// ログイン認証を行う
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UserProperties> Login(string id, string password);

        /// <summary>
        /// プロパティ情報を取得する
        /// </summary>
        /// <returns></returns>
        Task<UserProperties> GetProperties();
    }
}
