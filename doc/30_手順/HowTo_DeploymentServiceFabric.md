# Service Fabricデプロイ手順 with Powershell

1. Service FabricのクラスタをAzureポータルから作る
1. デプロイ用パッケージを作成する
1. デプロイ用パッケージをService Fabricクラスタにアップロードする

## Service Fabricのデプロイ用パッケージ作成

1. Developer Command Prompt for VS2015を起動する
1. Circle.sfprojのあるディレクトリに移動する
1. 以下コマンドを実行する

```
msbuild /target:package
```

4. src\Circle\Circle\pkgにデプロイ用パッケージが出来上がる


## デプロイ用パッケージをService Fabricクラスタにアップロード

以下のコマンドを叩いた。

```
Import-Module "$ENV:ProgramFiles\Microsoft SDKs\Service Fabric\Tools\PSModule\ServiceFabricSDK\ServiceFabricSDK.psm1"


cd C:\Users\J33778\Desktop\Circle-Deploytest

Connect-ServiceFabricCluster -ConnectionEndpoint "circle-deploytest.japaneast.cloudapp.azure.com:19000"
Copy-ServiceFabricApplicationPackage -ApplicationPackagePath CircleType -ImageStoreConnectionString (Get-ImageStoreConnectionStringFromClusterManifest(Get-ServiceFabricClusterManifest))
Register-ServiceFabricApplicationType CircleType
New-ServiceFabricApplication -ApplicationName fabric:/Circle -ApplicationTypeName "CircleType" -ApplicationTypeVersion "1.0.0"
```
