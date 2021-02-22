using System.Net.Http;

namespace SurveySolutionsClient.Apis
{
    /// <inheritdoc />
    public class SurveySolutionsApi : ISurveySolutionsApi
    {
        private readonly HttpClient httpClient;
        private readonly SurveySolutionsApiConfiguration options;

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveySolutionsApi"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The options.</param>
        public SurveySolutionsApi(HttpClient httpClient,
            SurveySolutionsApiConfiguration options)
        {
            this.httpClient = httpClient;
            this.options = options;
        }

        /// <inheritdoc />
        public virtual IAssignments Assignments => new AssignmentsApi(this.httpClient, this.options);

        /// <inheritdoc />
        public virtual IExport Export => new ExportApi(this.httpClient, this.options);

        public IInterviews Interviews => new InterviewsApi(this.httpClient, this.options);

        public IQuestionnaires Questionnaires => new QuestionnairesApi(this.httpClient, this.options);
    }
}