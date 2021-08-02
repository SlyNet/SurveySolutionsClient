using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;

namespace SurveySolutionsClient.Tests
{
    public class AssignmentsReadonlyTests
    {
        private HttpClient httpClient;
        private SurveySolutionsApi service;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.httpClient = new HttpClient();
            this.service = new SurveySolutionsApi(this.httpClient, ClientSettings.GetConfiguration());
        }
        
        [Test]
        public async Task can_get_assignment_details()
        {
            var response = await this.service.Assignments.DetailsAsync(6);
            Assert.That(response, Is.Not.Null);
        }
    }
}