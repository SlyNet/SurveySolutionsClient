using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NodaTime;
using NUnit.Framework;
using SurveySolutionsClient.Apis;
using SurveySolutionsClient.GraphQl;
using SurveySolutionsClient.Models;
using InterviewStatus = SurveySolutionsClient.GraphQl.InterviewStatus;
using QuestionnaireIdentity = SurveySolutionsClient.GraphQl.QuestionnaireIdentity;
using UserRoles = SurveySolutionsClient.GraphQl.UserRoles;

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
            var questionnaireIdArgument = new GraphQlQueryParameter<QuestionnaireIdentity>("id", new QuestionnaireIdentity
            {
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

            var result = await this.service.GraphQl.ExecuteAsync<GraphQlResponse>(builder);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Assignments.Nodes, Is.Not.Empty);
        }
        
        [Test]
        public async Task should_be_to_get_list_of_interviews_by_status()
        {
            var builder = new HeadquartersQueryQueryBuilder()
                .WithInterviews(
                    new IPagedConnectionOfInterviewQueryBuilder()
                        .WithNodes(new InterviewQueryBuilder().WithAllScalarFields())
                        .WithFilteredCount()
                        .WithTotalCount(),
                    workspace: "primary",
                    where: new InterviewsFilter()
                    {
                        Status = new InterviewStatusOperationFilterInput
                        {
                            Eq = InterviewStatus.Completed
                        }
                    });

            var result = await this.service.GraphQl.ExecuteAsync<GraphQlResponse>(builder);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task should_be_able_to_execute_mutation()
        {
            var builder = new HeadquartersMutationQueryBuilder()
                .WithAddInterviewCalendarEvent(
                    new CalendarEventQueryBuilder().WithAllScalarFields(),
                    workspace: "primary",
                    comment: "api call test",
                    startTimezone: DateTimeZoneProviders.Tzdb.GetSystemDefault().Id,
                    newStart: new DateTime(2011, 10, 11, 15, 30, 12),
                    interviewId: Guid.NewGuid()
                    );

            var result = await this.service.GraphQl.ExecuteAsync<GraphQlResponse>(builder);

            Assert.That(result, Is.Not.Null);

        }

        [Test]
        public async Task should_be_able_to_list_interviews()
        {
            var builder = new HeadquartersQueryQueryBuilder()
                .WithInterviews(
                    new IPagedConnectionOfInterviewQueryBuilder()
                        .WithNodes(new InterviewQueryBuilder().WithAllScalarFields())
                        .WithFilteredCount()
                        .WithTotalCount(),
                    where: new InterviewsFilter
                    {
                        Status = new InterviewStatusOperationFilterInput
                        {
                            Eq = InterviewStatus.Completed
                        }
                    },
                    workspace: "primary");

            var result = await this.service.GraphQl.ExecuteAsync<GraphQlResponse>(builder);

            Assert.That(result.Data.Interviews, Is.Not.Null);
            Assert.That(result.Data.Interviews.Nodes, Is.Not.Null.Or.Empty);
            Assert.That(result.Data.Interviews.Nodes.First().Id, Is.Not.Null);
        }

        [Test]
        public async Task should_be_able_to_get_list_of_interviewers()
        {
            SurveySolutionsApiConfiguration options = new SurveySolutionsApiConfiguration(new Credentials("admin", "Qwerty1234"), ClientSettings.HqUrl);
            var adminApiService = new SurveySolutionsApi(httpClient, options);
            var builder = new HeadquartersQueryQueryBuilder()
                .WithUsers(new UsersQueryBuilder()
                        .WithNodes(new UserQueryBuilder().WithAllScalarFields())
                        .WithFilteredCount()
                        .WithTotalCount(),
                    where: new UsersFilterInput
                    {
                        Role = new RoleFilterInput {Eq = UserRoles.Interviewer}
                    }, 
                    order: new[]
                    {
                        new UsersSortInput
                        {
                            FullName = SortEnumType.Asc
                        }
                    });

            var result = await adminApiService.GraphQl.ExecuteAsync<GraphQlResponse>(builder);

            Assert.That(result.Data.Users, Is.Not.Null);
            Assert.That(result.Data.Users.Nodes, Is.Not.Null.Or.Empty);
            Assert.That(result.Data.Users.Nodes.All(x => x.Role == UserRoles.Interviewer));
        }

        [OneTimeTearDown]
        public void TearDown()
        {

        }
    }
}