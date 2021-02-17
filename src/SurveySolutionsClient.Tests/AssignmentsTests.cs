using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class AssignmentsTests
    {
        private HttpClient httpClient;
        private ISurveySolutionsApi service;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            httpClient = new HttpClient();
            service = new SurveySolutionsApi(httpClient, ClientSettings.GetConfiguration());
        }

        [Test]
        public async Task can_get_assignment_details()
        {
            var response = await service.Assignments.DetailsAsync(1);
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task can_get_list_of_assignments()
        {
            var response = await service.Assignments.ListAsync(new AssignmentsListFilter
            {
                Limit = 5
            });
            Assert.That(response, Is.Not.Null);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}