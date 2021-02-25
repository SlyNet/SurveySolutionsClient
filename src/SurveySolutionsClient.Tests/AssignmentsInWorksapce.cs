using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class AssignmentsInWorkspace
    {
        private HttpClient httpClient;
        private ISurveySolutionsApi service;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            httpClient = new HttpClient();
            service = new SurveySolutionsApi(httpClient, ClientSettings.GetConfiguration("second"));
        }

        [Test]
        public async Task should_be_able_to_query_in_workspace()
        {
            var list = await this.service.Assignments.ListAsync(new AssignmentsListFilter());
            Assert.That(list, Is.Not.Null);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }


}