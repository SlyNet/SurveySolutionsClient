using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class WorkspacesApiTests
    {
        private HttpClient httpClient;
        private IWorkSpaces service;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            httpClient = new HttpClient();
            service = new SurveySolutionsApi(httpClient, 
                new SurveySolutionsApiConfiguration(new Credentials("admin", "Qwerty1234"), 
                    ClientSettings.GetConfiguration().BaseUrl)).WorkSpaces;
        }

        [Test]
        public async Task can_get_list()
        {
            var workspacesList = await this.service.ListAsync(new WorkspacesListFilter());
            Assert.That(workspacesList.Workspaces, Has.Count.EqualTo(1));
        }

        [Test]
        public async Task can_create_workspace()
        {
           var result =  await this.service.CreateAsync(new WorkspaceCreateRequest(
                "test1",
                "my display name"
            ));
           Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task can_disable()
        {
            await this.service.DisableAsync("test1");
        }

        [Test]
        public async Task can_enable()
        {
            await this.service.EnableAsync("test1");
        }

        [Test]
        public async Task can_update()
        {
            await this.service.UpdateAsync("test1", new WorkspaceUpdateRequest("updated"));
        }

        [Test]
        public async Task can_get_status()
        {
            var workspaceStatus = await this.service.GetStatusAsync("test1");
            Assert.That(workspaceStatus, Is.Not.Null);
        }

        [Test]
        public async Task can_assign()
        {
            await this.service.AssignAsync(new AssignWorkspacesToUserRequest
            {
                UserIds = new Guid[] {Guid.Parse("26fb2fcf-e0ad-4e78-b9ba-cd85171d8f48")},
                Mode = AssignWorkspacesMode.Add,
                Workspaces = new[] {"test1"}
            });
        }

        [Test]
        public async Task can_delete()
        {
            await this.service.DeleteAsync("test1");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}