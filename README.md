[![NuGet package](https://img.shields.io/nuget/v/SurveySolutionsClient)](https://www.nuget.org/packages/SurveySolutionsClient/)

# Survey Solutions Client
C# client library to access Survey Solutions public api.

## To get started using api:
1. create a new api user as described [here](https://docs.mysurvey.solutions/headquarters/api/survey-solutions-api/). 
2. Install [nuget package](https://www.nuget.org/packages/SurveySolutionsClient/)
3. Then create a api client with following code sample:

```csharp
Credentials creds = new Credentials("apiUser", "apiPassword");
string surveySolutionsUrl = "https://demo.mysruvey.solutions";
var surveySolutionsApiConfiguration = new SurveySolutionsApiConfiguration(creds, surveySolutionsUrl);
var client = new SurveySolutionsApi(new HttpClient(), surveySolutionsApiConfiguration);
var assignmentsList = await client.Assignments.ListAsync(new AssignmentsListFilter());
```
More usage examples can be found in [tests folder](https://github.com/SlyNet/SurveySolutionsClient/tree/main/src/SurveySolutionsClient.Tests)


## Dependency Injection

Please use https://www.nuget.org/packages/SurveySolutionsClient.DependencyInjection package to use C# client with Microsoft.Extensions.DependencyInjection library.

Sample configuration in Net 6.0 application

```csharp
using SurveySolutionsClient;

var builder = WebApplication.CreateBuilder(args);

Credentials creds = new Credentials("apiUser", "apiPassword");
string surveySolutionsUrl = "https://demo.mysruvey.solutions";

builder.Services.ConfigureSurveySolutionsApiClient(creds, surveySolutionsUrl);
builder.Services.AddSurveySolutionsApiClient();

var app = builder.Build();
app.Run();
```

## Options pattern
There is also support for [Options pattern in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0)

Let's assume, that You configration contains following section:
```json
"SurveySolutions": { 
    "UserName": "apiUser",
    "Password": "apiPassword",
    "Url": "https://demo.mysruvey.solutions",
    "Workspace": "agriculture"
}
```

Then in C# code

```csharp
using SurveySolutionsClient;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSurveySolutionsApiClient(builder.Configuration.GetSection("SurveySolutions"));
builder.Services.AddSurveySolutionsApiClient();

var app = builder.Build();
app.Run();
```