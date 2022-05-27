# Survey Solutions Client
C# client library to access Survey Solutions public api.

Create a api client with following code sample:

``` C#
Credentials creds = new Credentials("apiUser", "apiPassword");
string surveySolutionsUrl = "https://demo.mysruvey.solutions";
var surveySolutionsApiConfiguration = new SurveySolutionsApiConfiguration(creds, surveySolutionsUrl);
var client = new SurveySolutionsApi(new HttpClient(), surveySolutionsApiConfiguration);
var assignmentsList = await client.Assignments.ListAsync(new AssignmentsListFilter());
```
More usage examples can be found in [tests folder](https://github.com/SlyNet/SurveySolutionsClient/tree/main/src/SurveySolutionsClient.Tests)
