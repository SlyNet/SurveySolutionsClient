using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class SettingsApiTests
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
        public async Task get_global_notice()
        {
            var globalNoticeAsync = await this.service.Settings.GetGlobalNoticeAsync();
            Assert.That(globalNoticeAsync, Is.Not.Null);
        }

        [Test]
        public async Task set_global_notice()
        {
            await this.service.Settings.SetGlobalNoticeAsync(new GlobalNoticeRequest
            {
                Message = "test message"
            });
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}