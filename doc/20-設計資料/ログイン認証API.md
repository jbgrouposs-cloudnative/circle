# ログイン認証API設計

ログイン認証APIでは、以下のAPIを提供する。

|API名称|説明|
|---|---|
|login|認証が必要なAPIを呼び出すためのトークン値を取得する|

# login API仕様

login APIについて、取り扱うパラメータ情報およびAPI呼出を行うためのHTTPリクエストフォーマットおよび結果として得られるレスポンスフォーマット等の仕様を記載する。

## HTTPリクエスト仕様

### リクエストパラメータ

login APIの呼出時にセットするパラメータは、以下の通りである。

|パラメータ名称|パラメータ種別|説明|
|---|---|---|
|id|POST Body|ユーザID|
|password|POST Body|パスワード文字列|

### リクエスト例

```
POST https://restapi.example.com/login HTTP/1.1
Host: restapi.example.com
User-Agent: RESTfulAPI-Client

{ "id" : "user@example.com", "password" : "passw0rd" }
```

### Curlコマンドによるリクエスト例

```
curl http://localhost:8475/login -X POST -d "{ 'id':'user@example.com', 'password':'passw0rd' }" -H "Content-Type: application/json"
```

## HTTPレスポンス仕様

### レスポンスパラメータ

login APIの呼出結果として得られるパラメータは、以下の通りである。

| パラメータ名称 | 説明 |
| --- | --- |
| access_token | 認証が必要なAPIを呼び出すためのトークン値 |

### ステータスコード

login APIの処理結果のステータスを表すコードは以下の通りである。

|ステータスコード|ステータスメッセージ|備考|
|---|---|---|
|200|OK|login APIによる認証処理に成功|
|600|Login Failure|認証失敗|

### レスポンス例（正常ログイン）

```
{
    "statusCode" : "200",
    "statusMessage" : "OK",
    "data" : {
        "access_token" : "mF_9.B5f-4.1JqM"
    }
}
```

### レスポンス例（ログインエラー）

```
{
    "statusCode" : "600",
    "statusMessage" : "Login Failure"
}
```
