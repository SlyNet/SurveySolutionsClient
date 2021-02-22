using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Helpers;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Apis
{
    /// <inheritdoc />
    public class QuestionnairesApi : IQuestionnaires
    {
        private readonly SurveySolutionsApiConfiguration options;
        private readonly RequestExecutor requestExecutor;


        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionnairesApi"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The options.</param>
        public QuestionnairesApi(HttpClient httpClient, SurveySolutionsApiConfiguration options)
        {
            this.options = options;
            this.requestExecutor = new RequestExecutor(httpClient);
        }


        /// <inheritdoc />
        public Task<QuestionnairesList> ListAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var query = new {offset = page, limit = pageSize}.GetQueryString();

            return this.requestExecutor.GetAsync<QuestionnairesList>(
                this.options.BaseUrl, "/api/v1/questionnaires?" + query, this.options.Credentials, cancellationToken
            );
        }

        /// <inheritdoc />
        public Task<AudioRecordingEnabled> GetAudioRecordingEnabled(QuestionnaireIdentity questionnaireIdentity,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<AudioRecordingEnabled>(
                this.options.BaseUrl, $"/api/v1/questionnaires/{questionnaireIdentity.QuestionnaireId}/{questionnaireIdentity.Version}/recordAudio", this.options.Credentials, cancellationToken
            );
        }

        /// <inheritdoc />
        public Task SetAudioRecordingEnabledAsync(QuestionnaireIdentity questionnaireIdentity, RecordAudioRequest request,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PostAsync(
                this.options.BaseUrl, $"/api/v1/questionnaires/{questionnaireIdentity.QuestionnaireId}/{questionnaireIdentity.Version}/recordAudio",
                request, this.options.Credentials, cancellationToken
            );
        }
    }
}