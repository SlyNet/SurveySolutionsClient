using System.Net.Http;

namespace SurveySolutionsClient
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
        public virtual IAssignments Assignments => new AssignmentsApi(httpClient, options);
    }
}