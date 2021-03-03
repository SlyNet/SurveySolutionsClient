using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.GraphQl;
using SurveySolutionsClient.Models;
using QuestionnaireIdentity = SurveySolutionsClient.GraphQl.QuestionnaireIdentity;

namespace SurveySolutionsClient.Tests
{
    public class GrapqlTests
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
        public async Task should_be_to_get_list_of_assignments()
        {
            var questionnaireIdArgument = new GraphQlQueryParameter<QuestionnaireIdentity>("id", new QuestionnaireIdentity {
                Id = new ComparableGuidOperationFilterInput
                {
                    Eq = ClientSettings.Questionnaire.QuestionnaireId
                }
            });

            var builder = new HeadquartersQueryQueryBuilder()
                .WithAssignments(
                    new IPagedConnectionOfAssignmentQueryBuilder()
                        .WithNodes(new AssignmentQueryBuilder().WithAllScalarFields())
                        .WithFilteredCount()
                        .WithTotalCount(),
                    workspace: "primary",
                    where: new AssignmentsFilter
                    {
                        QuestionnaireId = questionnaireIdArgument
                    })
                .WithParameter(questionnaireIdArgument);

            var result = await this.service.GraphQl.ExecuteAsync<GraphqlResponse>(builder);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Assignments.Nodes, Is.Not.Empty);
        }

        [Test]
        public async Task should_be_able_to_execute_mutation()
        {
            var builder = new HeadquartersMutationQueryBuilder()
                .WithAddOrUpdateCalendarEvent(
                    new CalendarEventQueryBuilder().WithAllScalarFields(),
                    workspace: "primary",
                    interviewKey: "62-70-07-41",
                    comment:  "api call test",
                    newStart: new DateTime(2011, 10, 11, 15, 30, 12));

            var result = await this.service.GraphQl.ExecuteAsync<GraphqlResponse>(builder);

            Assert.That(result, Is.Not.Null);

        }

        [OneTimeTearDown]
        public void TearDown()
        {

        }
    }
}