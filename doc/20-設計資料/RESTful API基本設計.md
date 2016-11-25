# RESTful API基本設計


## Request format

### GET parameters

GETパラメータでデータを送信する場合、以下のようなHTTPリクエストを送信する。

例）送信するパラメータがparam1=hoge, param2=fugaの場合

```
GET https://restapi.example.com/path-to-api?param1=hoge&param2=fuga HTTP/1.1
Host: restapi.example.com
User-Agent: RESTfulAPI-Client
```

### POST Body parameters

POST Bodyパラメータでデータを送信する場合、以下のようにJSON形式のデータをHTTPリクエストを送信する。
JSONデータの内容はそれぞれのAPIリファレンスを参照。

例）送信するパラメータがparam1=hoge, param2=fugaの場合

```
POST https://restapi.example.com/path-to-api HTTP/1.1
Host: restapi.example.com
User-Agent: RESTfulAPI-Client
Content-Length: 40

{ "param1" : "fuga", "param2" : "fuga" }
```


### Authorization header

[RFC 6750](https://tools.ietf.org/html/rfc6750)に準拠し、ユーザ認証が必要なAPI呼び出し時には、Authorizationヘッダに対してアクセストークンを指定して呼び出すこととする。


```
GET https://restapi.example.com/required-auth-api HTTP/1.1
Host: restapi.example.com
User-Agent: RESTfulAPI-Client
Authorization: Bearer <token68 format>
```

## Response format

API処理結果のレスポンスはJSON形式のデータとして取得し、以下の基本フォーマットに従う。

```
{
    "statusCode" : "200",
    "statusMessage" : "OK",
    "data" : {
        /* APIの処理結果 */
    }
}
```

### statusCode & statusMessage

ステータスコードおよびそれぞれのステータスコードに対するメッセージの内容を表す。
各種API共通のステータスコードは以下の通り。

|statusCode|statusMessage|備考|
|:---|:---|:---|
|200|OK|API処理が成功した|
|400|BadRequest|パラメータ不正など|
|401|Unauthorized|認証が必要|
|402|NotFound|APIが存在しない|
|500|UnknownError|不明なエラー|
|600-999|???|API別にエラーを定義する|