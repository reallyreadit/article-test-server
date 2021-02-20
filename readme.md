# reallyread.it article-test-server
## Setup Guide
If you already completed the setup guide for the `api` repository you can skip steps 1 and 2 as this project shares the same development environment.
1. Install the .NET Core 3.1 SDK: https://dotnet.microsoft.com/download
2. Configure the ASP.NET core environment for development: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-3.1#set-the-environment

        export ASPNETCORE_ENVIRONMENT=Development
3. Create the following configuration files and modify as required. Network delay values are in milliseconds and are used to simulate a slow article server:

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
5. Restore packages

        dotnet restore
4. Build and run the server

        dotnet watch run