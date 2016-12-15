# フィード一覧取得API設計

フィード一覧取得APIでは、以下のAPIを提供する。

|API名称|説明|
|---|---|
|getFeedList|与えられたリクエストを元にフィード一覧を取得する|

# getFeedList API仕様

getFeedList APIについて、取り扱うパラメータ情報およびAPI呼出を行うためのHTTPリクエストフォーマットおよび結果として得られるレスポンスフォーマット等の仕様を記載する。

## HTTPリクエスト仕様

### リクエストパラメータ

getFeedList APIの呼出時にセットするパラメータは、以下の通りである。

|パラメータ名称|パラメータ種別|説明|
|---|---|---|
|language|POST Body|言語種別(Java,Ruby,etc...)|
|searchStr|POST Body|検索文字列|
|feedTag|POST Body|フィードタグ|
|sortType|POST Body|ソート順(新着順・関連順・ストック順)|
|stockFlag|POST Body|ストック済フラグ|
|searchUserId|POST Body|ユーザーID(検索者)|
|postUserId|POST Body|ユーザーID(投稿者)|
|postDateTime|POST Body|投稿日時|
|updateDateTime|POST Body|更新日時|
|newFeedFlag|POST Body|新着フラグ(不要？)|
|favFeedFlag|POST Body|人気の投稿フラグ(不要？)|
|companyId|POST Body|所属企業ID(不要？)|

### リクエスト例

```
POST https://restapi.example.com/getFeedList HTTP/1.1
Host: restapi.example.com
User-Agent: RESTfulAPI-Client

{ 
    "language" : "",
    "searchStr" : "",
    "tag" : "",
    "sortType" : "",
    "stockFlag" : "",
    "searchUserId" : "",
    "postUserId" : "",
    "postDateTime" : "",
    "updateDateTime" : "",
    "newFeedFlag" : "",
    "favFeedFlag" : "",
    "companyId" : ""
}
```

### Curlコマンドによるリクエスト例

```
curl https://restapi.example.com/getFeedList -X POST -d 
    '{  "language" : "", "searchStr" : "", "tag" : "", "sortType" : "",
        "stockFlag" : "", "searchUserId" : "", "postUserId" : "", "postDateTime" : "",
        "updateDateTime" : "", "newFeedFlag" : "", "favFeedFlag" : "", "companyId" : ""}'
```

## HTTPレスポンス仕様

### レスポンスパラメータ

getFeedList APIの呼出結果として得られるパラメータは、以下の通りである。

|パラメータ名称|説明|
|---|---|
|language|言語種別(Java,Ruby,etc...)|
|feedId|フィード管理ID|
|feedTitle|フィードタイトル|
|feedTags|フィードタグ(配列)|
|stockFlag|ストック済フラグ|
|favNum|いいね数|
|commentNum|コメント数|
|postUserId|ユーザーID(投稿者)|
|postDateTime|投稿日時|
|updateDateTime|更新日時|
|newFeedFlag|新着フラグ(不要？)|

### ステータスコード

getFeedList APIの処理結果のステータスを表すコードは以下の通りである。

|ステータスコード|ステータスメッセージ|備考|
|---|---|---|
|200|OK|フィード一覧取得成功|
|600|getFeedList Failure|フィード一覧取得失敗|

### レスポンス例（フィード一覧取得成功）

```
{
    "statusCode" : "200",
    "statusMessage" : "OK",
    "data" : {
        "language" : "",
        "feedId" : "",
        "feedTitle" : "",
        "feedTags" : "",
        "stockFlag" : "",
        "favNum" : "",
        "commentNum" : "",
        "postUserId" : "",
        "postDateTime" : "",
        "updateDateTime" : "",
        "newFeedFlag" : ""
    }
}
```

### レスポンス例（フィード一覧取得エラー）

```
{
    "statusCode" : "600",
    "statusMessage" : "getFeedList Failure"
}
```
