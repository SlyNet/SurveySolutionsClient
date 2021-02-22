using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;

namespace SurveySolutionsClient.Tests
{
    public class UsersApiTests
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
        public async Task get_interviewer_details()
        {
            var interviewer =
                await this.service.Users.GetInterviewerDetailsAsync(Guid.Parse("30b5216a-5df8-4bdc-b4aa-91606190354b"));
            Assert.That(interviewer, Is.Not.Null);
        }

        [Test]
        public async Task get_supervisors_list()
        {
            var supervisorsList = await this.service.Users.SupervisorsListAsync();
            Assert.That(supervisorsList, Is.Not.Null);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}