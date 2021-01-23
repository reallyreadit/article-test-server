# reallyread.it article-test-server
## Configuration
Create the following configuration files and modify as required. Network delay values are in milliseconds:

    hosting.json
```json
{
	"server.urls": "http://0.0.0.0:5002"
}
```
    appsettings.json
```json
{
  "NetworkDelay": {
    "ArticlePageDelay": 0,
    "CssFileDelay": 0,
    "HomePageDelay": 0,
    "ImageFileDelay": 0,
    "JavascriptFileDelay": 0
  },
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  }
}
```