using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Exceptions;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    
    public class InterviewTests
    {
        private HttpClient httpClient;
        private ISurveySolutionsApi service;
        private Guid interviewId = Guid.Parse("df7ff092049a48cfa97a1b6142ad2a04");

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            httpClient = new HttpClient();
            service = new SurveySolutionsApi(httpClient, ClientSettings.GetConfiguration());
        }

        [Test]
        public async Task able_to_get_interview_details()
        {
            var interview = await this.service.Interviews.DetailsAsync(this.interviewId);
            Assert.That(interview, Is.Not.Null);
        }

        [Test(Description = "Should throw for completed interview")]
        public async Task able_to_delete_interview()
        {
            try
            {
                await this.service.Interviews.DeleteAsync(this.interviewId);
            }
            catch (ApiCallException e)
            {
                Assert.That(e.ResponseBody, Is.Not.Empty);
            }
            
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
            var tempFileName = Path.GetTempFileName();
            try
            {
                await using var fileStream = File.Open(tempFileName, FileMode.Create);
                await pdf.CopyToAsync(fileStream);

                Assert.That(File.Exists(tempFileName));
            }
            finally
            {
                File.Delete(tempFileName);                
            }
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
            await this.service.Interviews.ApproveAsync(Guid.Parse("b9ba6cb13d4142bdafbaba223af3bdad"), "my api comment");
        }

        [Test]
        public async Task should_be_able_to_assign()
        {
            await this.service.Interviews.AssignAsync(Guid.Parse("83355765353d4bc6a7223482a8588dd8"),
                new AssignInterviewRequest(null, "inter1"));
        }

        [Test]
        public async Task should_be_able_to_add_comment()
        {
            await this.service.Interviews.CommentAsync(Guid.Parse("4f7ff718d6dd42a1832db332e620159b"), "numeric13",
                "my comment", new RosterVector(0));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}