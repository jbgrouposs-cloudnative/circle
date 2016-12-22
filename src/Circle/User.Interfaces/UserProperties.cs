namespace User.Interfaces
{
    /// <summary>
    /// ユーザ情報
    /// </summary>
    public class UserProperties
    {
        /// <summary>
        /// ログイン用ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// パスワードのハッシュ値
        /// </summary>
        public string HashedPassword { get; set; }

        /// <summary>
        /// 姓
        /// </summary>
        public string FamilyName { get; set; }

        /// <summary>
        /// 名
        /// </summary>
        public string PersonalName { get; set; }
        
        /// <summary>
        /// メールアドレス
        /// </summary>
        public string MailAddress { get; set; }

        /// <summary>
        /// 認証トークン
        /// </summary>
        public string Token { get; set; }
    }
}