using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.WebAPI.Models
{
    /// <summary>
    /// レスポンスデータ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseData<T>
    {

        /// <summary>
        /// ステータスコード
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// ステータスメッセージ
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// 結果データ
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="statusCode">ステータスコード</param>
        /// <param name="statusMessage">ステータスメッセージ</param>
        public static ResponseData<T> Build(string statusCode, string statusMessage)
        {
            return new ResponseData<T>()
            {
                StatusCode = statusCode,
                StatusMessage = statusMessage
            };
        }

        public static ResponseData<T> BuildOK(T data)
        {
            return new ResponseData<T>()
            {
                StatusCode = "200",
                StatusMessage = "OK",
                Data = data
            };
        }
    }
}