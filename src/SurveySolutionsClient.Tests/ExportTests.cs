using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class ExportTests
    {
        private HttpClient httpClient;
        private ISurveySolutionsApi service;
        private QuestionnaireIdentity questionnaireIdentity;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            httpClient = new HttpClient();
            service = new SurveySolutionsApi(httpClient, ClientSettings.GetConfiguration());
            questionnaireIdentity = ClientSettings.Questionnaire;
        }

        [Test]
        public async Task should_be_able_to_list_jobs()
        {
            var jobs = await this.service.Export.ListAsync(new ExportListRequest(this.questionnaireIdentity)
            {
                ExportStatus = ExportStatus.Completed
            });

            Assert.That(jobs, Is.Not.Null);
        }

        [Test]
        public async Task should_be_able_to_schedule_job_and_cancel()
        {
            var job = await this.service.Export.StartAsync(new CreateExportProcess(this.questionnaireIdentity));
            
            Assert.That(job, Is.Not.Null);
            Assert.That(job.JobId, Is.Not.EqualTo(0));

            var job1 = await this.service.Export.CancelAsync(job.JobId);
            Assert.That(job1, Is.Not.Null);
        }

        [Test]
        public async Task should_be_able_to_get_single_export()
        {
            var job = await this.service.Export.DetailsAsync(3);
            Assert.That(job, Is.Not.Null);
            Assert.That(job.JobId, Is.Not.EqualTo(0));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}