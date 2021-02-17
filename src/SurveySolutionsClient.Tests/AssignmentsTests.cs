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

        [Test]
        public async Task can_get_history_of_assignment()
        {
            var response = await service.Assignments.HistoryAsync(1);
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task can_get_audio_recording_setting()
        {
            var response = await service.Assignments.GetAudioRecordingAsync(1);
            Assert.That(response, Is.Not.Null);
        }

        [Test]
        public async Task can_set_audio_recording()
        {
            await service.Assignments.SetAudioRecordingAsync(1, new UpdateRecordingRequest
            {
                Enabled = true
            });

            var response = await service.Assignments.GetAudioRecordingAsync(1);
            Assert.That(response.Enabled, Is.True);
        }

        [Test]
        public async Task can_archive_assignment()
        {
            var archiveAsync = await this.service.Assignments.ArchiveAsync(1);

            Assert.That(archiveAsync.Archived, Is.True);
        }

        [Test]
        public async Task can_unarchive_assignment()
        {
            var archiveAsync = await this.service.Assignments.UnArchiveAsync(1);

            Assert.That(archiveAsync.Archived, Is.False);
        }

        [Test]
        public async Task can_assign()
        {
            var archiveAsync = await this.service.Assignments.AssignAsync(1, new AssignmentAssignRequest
            {
                Responsible = "inter1"
            });

            Assert.That(archiveAsync.ResponsibleName, Is.EqualTo("inter1"));
        }

        [Test]
        public async Task can_change_quanity()
        {
            var archiveAsync = await this.service.Assignments.ChangeQuantityAsync(1, 10);

            Assert.That(archiveAsync.Quantity, Is.EqualTo(10));
        }

        [Test]
        public async Task should_be_able_to_close_assignment()
        {
            var archiveAsync = await this.service.Assignments.CloseAsync(1);

            Assert.That(archiveAsync.Quantity, Is.EqualTo(0));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}