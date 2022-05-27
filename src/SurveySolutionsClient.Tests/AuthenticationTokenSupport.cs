using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests;

[TestFixture]
public class AuthenticationTokenSupport
{
    private const string authToken =
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI4YzU3Nzg2MDAyZjY0YjNmYTEzZmQ4NjBlNzk0OTE0MiIsImp0aSI6ImRlY2U5ODZkYzhmZDQ5ODU5NTU2ODk4ODg0ODA0YTA3IiwibmJmIjoxNjUzNjY3MDAwLCJleHAiOjE2Njk0MzUwMDAsImlzcyI6IlN1cnZleS5Tb2x1dGlvbnMiLCJhdWQiOiJBbGwifQ.y1pmLhy2Y1RrtiJ-BJJznhwBRDaLbRMjcvoeBLie42Q";

    [Test]
    public async Task test_call_with_auth_token()
    {
        var httpClient = new HttpClient();
        var client = new SurveySolutionsApi(httpClient, new SurveySolutionsApiConfiguration(new Credentials(authToken), 
            ClientSettings.HqUrl));

        var assignments = await client.Assignments.ListAsync(new AssignmentsListFilter());
        
        Assert.That(assignments, Is.Not.Null);
    }
}