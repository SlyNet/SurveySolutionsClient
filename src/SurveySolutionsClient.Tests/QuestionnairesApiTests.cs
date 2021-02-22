using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class QuestionnairesApiTests
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
        public async Task should_be_able_to_get_list_of_questionnaires()
        {
            var questionnaires = await this.service.Questionnaires.ListAsync();

            Assert.That(questionnaires, Is.Not.Null);
            Assert.That(questionnaires.Questionnaires, Is.Not.Empty);
        }


        [Test]
        public async Task should_be_able_to_get_questionnaire_document()
        {
            var audio = await this.service.Questionnaires.GetAudioRecordingEnabled(ClientSettings.Questionnaire);
            Assert.That(audio, Is.Not.Null);
        }

        [Test]
        public async Task should_be_able_to_set_questionnaire_document()
        {
            await this.service.Questionnaires.SetAudioRecordingEnabledAsync(ClientSettings.Questionnaire, new RecordAudioRequest
            {
                Enabled = true
            });
        }



        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}