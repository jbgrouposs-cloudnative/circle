# コメント一覧取得API設計

コメント一覧取得APIでは、以下のAPIを提供する。

|API名称|説明|
|---|---|
|getCommentList|与えられたリクエストを元にコメント一覧を取得する|

# getCommentList API仕様

getCommentList APIについて、取り扱うパラメータ情報およびAPI呼出を行うためのHTTPリクエストフォーマットおよび結果として得られるレスポンスフォーマット等の仕様を記載する。

## HTTPリクエスト仕様

### リクエストパラメータ

getCommentList APIの呼出時にセットするパラメータは、以下の通りである。

|パラメータ名称|パラメータ種別|説明|
|---|---|---|
|feedId|POST Body|フィードID|


### リクエスト例

```
POST https://restapi.example.com/getCommentList HTTP/1.1
Host: restapi.example.com
User-Agent: RESTfulAPI-Client

{ 
    "feedId" : ""
}
```

### Curlコマンドによるリクエスト例

```
curl https://restapi.example.com/getCommentList -X POST -d 
    '{  "feedId" : ""}'
```

## HTTPレスポンス仕様

### レスポンスパラメータ

getCommentList APIの呼出結果として得られるパラメータは、以下の通りである。

|パラメータ名称|説明|
|---|---|
|feedId|POST Body|フィードID|
|commentId|POST Body|コメントId|
|commentUserId|POST Body|ユーザーID(コメント)|
|comment|POST Body|コメント内容|
|comPostDateTime|POST Body|コメント投稿日時|
|comUpdateDateTime|POST Body|コメント更新日時|

### ステータスコード

getFeedList APIの処理結果のステータスを表すコードは以下の通りである。

|ステータスコード|ステータスメッセージ|備考|
|---|---|---|
|200|OK|コメント一覧取得成功|
|400|getCommentList Failure|コメント一覧取得失敗|

### レスポンス例（フィード一覧取得成功）

```
{
    "statusCode" : "200",
    "statusMessage" : "OK",
    "data" : {
        "feedId" : "",
        "commentId" : "",
        "commentUserId" : "",
        "comment" : "",
        "comPostDateTime" : "",
        "comUpdateDateTime" : ""
    }
}
```

### レスポンス例（コメント一覧取得エラー）

```
{
    "statusCode" : "400",
    "statusMessage" : "getCommentList Failure"
}
```
