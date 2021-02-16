# reallyread.it article-test-server
## Configuration
Create the following configuration files and modify as required. Network delay values are in milliseconds:

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
		"LogLevel": {
			"Default": "Information",
			"Microsoft": "Warning",
			"Microsoft.Hosting.Lifetime": "Information"
		}
	},
	"AllowedHosts": "*",
	"Kestrel": {
		"Endpoints": {
			"Http": {
				"Url": "http://localhost:5002"
			}
		}
	}
}
```