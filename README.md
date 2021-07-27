[![NuGet package](https://img.shields.io/nuget/v/SurveySolutionsClient)](https://www.nuget.org/packages/SurveySolutionsClient/)

# Survey Solutions Client
C# client library to access Survey Solutions public api.

## To get started using api:
1. create a new api user as described [here](https://docs.mysurvey.solutions/headquarters/api/survey-solutions-api/). 
2. Install [nuget package](https://img.shields.io/nuget/v/SurveySolutionsClient)
3. Then create a api client with following code sample:

``` C#
Credentials creds = new Credentials("apiUser", "apiPassword");
string surveySolutionsUrl = "https://demo.mysruvey.solutions";
var surveySolutionsApiConfiguration = new SurveySolutionsApiConfiguration(creds, surveySolutionsUrl);
var client = new SurveySolutionsApi(new HttpClient(), surveySolutionsApiConfiguration);
var assignmentsList = await client.Assignments.ListAsync(new AssignmentsListFilter());
```
More usage examples can be found in [tests folder](https://github.com/SlyNet/SurveySolutionsClient/tree/main/src/SurveySolutionsClient.Tests)
