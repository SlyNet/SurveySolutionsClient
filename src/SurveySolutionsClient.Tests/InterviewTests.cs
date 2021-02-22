using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    
    public class InterviewTests
    {
        private HttpClient httpClient;
        private ISurveySolutionsApi service;
        private QuestionnaireIdentity questionnaireIdentity;
        private Guid interviewId = Guid.Parse("35b7fbb3b66749d5bf912fd048f36a13");

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            httpClient = new HttpClient();
            service = new SurveySolutionsApi(httpClient, ClientSettings.GetConfiguration());
            questionnaireIdentity = ClientSettings.Questionnaire;
        }

        [Test]
        public async Task able_to_get_interview_details()
        {
            var interview = await this.service.Interviews.DetailsAsync(this.interviewId);
            Assert.That(interview, Is.Not.Null);
        }

        [Test]
        public async Task able_to_delete_interview()
        {
            await this.service.Interviews.DeleteAsync(this.interviewId);
        }


        [Test]
        public async Task able_to_get_history()
        {
            var interviewHistory = await this.service.Interviews.HistoryAsync(this.interviewId);
            Assert.That(interviewHistory, Is.Not.Null);
            Assert.That(interviewHistory.Records, Has.Count.GreaterThan(1));
        }

        [Test]
        public async Task able_to_download_pdf()
        {
            var pdf = await this.service.Interviews.GetPdfAsync(this.interviewId);
            await using var fileStream = File.Open("c:/temp/file.pdf", FileMode.Create);
            await pdf.CopyToAsync(fileStream);

            Assert.That(File.Exists("c:/temp/file.pdf"));
        }

        [Test]
        public async Task able_get_interview_statistics()
        {
            var stats = await this.service.Interviews.StatisticsAsync(this.interviewId);
            Assert.That(stats, Is.Not.Null);
        }

        [Test]
        public async Task should_be_able_to_approve()
        {
            await this.service.Interviews.ApproveAsync(Guid.Parse("577a1b05706f455f80a967f05d813438"), "my api comment");
        }

        [Test]
        public async Task should_be_able_to_assign()
        {
            await this.service.Interviews.AssignAsync(Guid.Parse("a5f20fd17a4546c4b6ddde9f6570cd03"),
                new AssignInterviewRequest(null, "inter1"));
        }

        [Test]
        public async Task should_be_able_to_add_comment()
        {
            await this.service.Interviews.CommentAsync(Guid.Parse("4f7ff718d6dd42a1832db332e620159b"), "date",
                "my comment", new RosterVector(0));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}