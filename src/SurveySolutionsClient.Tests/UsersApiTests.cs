using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Models;

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

        [Test]
        public async Task get_supervisor_details()
        {
            var supervisor = await this.service.Users.GetUserDetailsAsync("sup");
            Assert.That(supervisor, Is.Not.Null);
        }

        [Test]
        public async Task get_supervisor_by_id()
        {
            var supervisor = await this.service.Users.GetSupervisorDetailsAsync(Guid.Parse("46f5f6f9-00a6-4a36-9fcb-50d7dc20f4c7"));
            Assert.That(supervisor, Is.Not.Null);
        }

        [Test]
        public async Task can_archive()
        {
            await this.service.Users.Archive(Guid.Parse("0ec2229c-29c1-45d8-954a-121e55d244a2"));
        }

        [Test]
        public async Task can_un_archive()
        {
            await this.service.Users.UnArchive(Guid.Parse("0ec2229c-29c1-45d8-954a-121e55d244a2"));
        }

        [Test]
        public async Task can_get_actions_log()
        {
            var actions = await this.service.Users.GetActionsLogAsync(Guid.Parse("30b5216a-5df8-4bdc-b4aa-91606190354b"));
            Assert.That(actions, Is.Not.Null);
        }

        [Test]
        public async Task can_register_user()
        {
            await this.service.Users.RegisterAsync(new RegisterUserModel
            {
                UserName = "test",
                Role = Roles.Interviewer,
                Password = "Pa$$Word1111",
                Supervisor = "sup"
            });
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}