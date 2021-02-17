using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <inheritdoc />
    public class AssignmentsApi : IAssignments
    {
        private readonly SurveySolutionsApiConfiguration options;
        private readonly RequestExecutor requestExecutor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentsApi"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The options.</param>
        public AssignmentsApi(HttpClient httpClient, 
            SurveySolutionsApiConfiguration options)
        {
            this.options = options;
            this.requestExecutor = new RequestExecutor(httpClient);
        }

        /// <inheritdoc />
        public virtual Task<FullAssignmentDetails> DetailsAsync(int id, CancellationToken cancellationToken = default) =>
            this.requestExecutor
                .GetAsync<FullAssignmentDetails>(options.BaseUrl, $"api/v1/assignments/{id}", options.Credentials, cancellationToken);

        /// <inheritdoc />
        public virtual Task<AssignmentsListView> ListAsync(AssignmentsListFilter filter, CancellationToken cancellationToken = default)
        {
            string queryString = filter.GetQueryString();

            return this.requestExecutor
                .GetAsync<AssignmentsListView>(options.BaseUrl, "api/v1/assignments?" + queryString, options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public virtual Task<AssignmentHistory> HistoryAsync(int id, int start = 0, int length = 30, CancellationToken cancellationToken = default)
        {
            var query = new {start, length}.GetQueryString();

            return this.requestExecutor
                .GetAsync<AssignmentHistory>(options.BaseUrl, $"api/v1/assignments/{id}/history?" + query, options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<AssignmentAudioRecordingEnabled> GetAudioRecordingAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .GetAsync<AssignmentAudioRecordingEnabled>(options.BaseUrl, $"api/v1/assignments/{id}/recordAudio", options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task SetAudioRecordingAsync(int id, UpdateRecordingRequest request, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync(options.BaseUrl, $"api/v1/assignments/{id}/recordAudio", request, options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<AssignmentDetails> ArchiveAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<AssignmentDetails>(options.BaseUrl, $"api/v1/assignments/{id}/archive", null, options.Credentials, cancellationToken);
        }

        public Task<AssignmentDetails> UnArchiveAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<AssignmentDetails>(options.BaseUrl, $"api/v1/assignments/{id}/unarchive", null, options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<AssignmentDetails> AssignAsync(int id, AssignmentAssignRequest assigneeRequest, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<AssignmentDetails>(options.BaseUrl, $"api/v1/assignments/{id}/assign", assigneeRequest, options.Credentials, cancellationToken);
        }

        public Task<AssignmentDetails> ChangeQuantityAsync(int id, int quantity, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<AssignmentDetails>(options.BaseUrl, $"api/v1/assignments/{id}/changeQuantity", quantity, options.Credentials, cancellationToken);
        }

        public Task<AssignmentDetails> CloseAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<AssignmentDetails>(options.BaseUrl, $"api/v1/assignments/{id}/close", null, options.Credentials, cancellationToken);
        }
    }
}