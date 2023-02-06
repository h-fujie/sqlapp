# sqlapp

## 前提条件

Windowsコンテナを利用できるDocker環境が用意されている

## 実行手順

1. [Download Microsoft® SQL Server® 2014 Express from Official Microsoft Download Center](https://www.microsoft.com/en-US/download/details.aspx?id=42299) より `SQLEXPR_x64_ENU.exe` をダウンロードする
2. ダウンロードしたファイルを `sqlapp/db` に移動する
3. コンテナを起動
  ```cmd
  docker compose up -d
  ```
4. 実行結果を確認
  ```cmd
  docker logs app
  ```

## 実行結果

```cmd
C:\Users\hfuji\develop\docker\sqlapp>docker compose up -d
[+] Running 3/3
 - Network sqlapp_default  Created                                                                                        0.1s
 - Container app           Started                                                                                        7.9s
 - Container db            Started                                                                                        1.7s

C:\Users\hfuji\develop\docker\sqlapp>docker logs app
0001, 1
1000, 1
1234, 1
A001, 0
A123, 0

```
