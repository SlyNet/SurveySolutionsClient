using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.Exceptions;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Tests
{
    public class AssignmentsTests
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
            var archiveAsync = await this.service.Assignments.AssignAsync(1, new AssignmentResponsible("inter1"));

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

        [Test]
        public void should_be_able_to_receive_validation_errors_during_assignment_creation()
        {
            var exception = Assert.ThrowsAsync<AssignmentCreationException>(() => 
                this.service.Assignments.CreateAsync(new CreateAssignmentRequest
                {
                    QuestionnaireId = questionnaireIdentity,
                    Comments = "comment",
                    Email = "test@test.com",
                    IsAudioRecordingEnabled = true,
                    Password = "pwd123411",
                    ProtectedVariables = new List<string> {"yn1"},
                    Quantity = 5,
                    Responsible = "inter",
                    WebMode = true
                }));

            Assert.That(exception.CreationResult.VerificationStatus.Errors, Is.Not.Empty);
        }

        [Test]
        public async Task should_be_able_to_create_assignment_without_values()
        {
            var creationResult = await this.service.Assignments.CreateAsync(new CreateAssignmentRequest
                {
                    QuestionnaireId = questionnaireIdentity,
                    Comments = "comment",
                    IsAudioRecordingEnabled = true,
                    ProtectedVariables = new List<string> {"yn1"},
                    Quantity = 5,
                    Responsible = "inter",
                });

            Assert.That(creationResult.Assignment, Is.Not.Null);
        }

        [Test]
        public async Task should_be_able_to_create_assignment_with_answer()
        {
            var creationResult = await this.service.Assignments.CreateAsync(new CreateAssignmentRequest
            {
                QuestionnaireId = questionnaireIdentity,
                Quantity = 5,
                Responsible = "inter",
                IdentifyingData = new List<AssignmentIdentifyingDataItem>
                {
                    new AssignmentIdentifyingDataItem // text question
                    {
                        Answer = "text question",
                        Variable = "text6"
                    },
                    new AssignmentIdentifyingDataItem // numeric question
                    {
                        Answer = "1",
                        Variable = "numeric7"
                    },
                    new AssignmentIdentifyingDataItem // list question
                    {
                        Answer = JsonSerializer.Serialize(new []{ "one", "two", "three" }),
                        Variable = "listR1"
                    },
                    new AssignmentIdentifyingDataItem // gps question
                    {
                        Variable = "gps",
                        Answer = "48.7630568$30.1807397"
                    },
                    new AssignmentIdentifyingDataItem // multiple choice question
                    {
                        Variable = "ms16",
                        Answer =  JsonSerializer.Serialize(new []{ "-2", "3" }),
                    },
                    new AssignmentIdentifyingDataItem // question in roster
                    {
                        Answer = "test answer inside roster",
                        Identity = new Identity(Guid.Parse("7cc0482b99db1f48a4aff9e04fbd2f71"), new RosterVector(-2))
                    },
                    new AssignmentIdentifyingDataItem // yes no question
                    {
                        Variable = "yn1",
                        Answer = JsonSerializer.Serialize(new [] { "20 -> yes", "30 -> no" })
                    }
                }
            });

            Assert.That(creationResult.Assignment, Is.Not.Null);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            httpClient?.Dispose();
        }
    }
}