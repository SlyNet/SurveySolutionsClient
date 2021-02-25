[![NuGet](https://img.shields.io/nuget/v/MvvmCross.svg)](https://www.nuget.org/packages/MvvmCross/)

# SurveySolutionsClient
C# client library to access Survey Solutions public api.

To get started using api create a new api user as described [here](https://docs.mysurvey.solutions/headquarters/api/survey-solutions-api/). Then create a api client with following code sample:

``` C#
Credentials creds = new Credentials("apiUser", "apiPassword");
string surveySolutionsUrl = "https://demo.mysruvey.solutions";
var client = new SurveySolutionsApi(new HttpClient(), new SurveySolutionsApiConfiguration(creds, surveySolutionsUrl));
var assignmentsList = await client.Assignments.ListAsync(new AssignmentsListFilter());
```
