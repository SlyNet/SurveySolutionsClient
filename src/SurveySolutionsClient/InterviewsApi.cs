using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <inheritdoc />
    public class InterviewsApi : IInterviews
    {
        private RequestExecutor requestExecutor;
        private SurveySolutionsApiConfiguration options;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterviewsApi"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The options.</param>
        public InterviewsApi(HttpClient httpClient, SurveySolutionsApiConfiguration options)
        {
            this.requestExecutor = new RequestExecutor(httpClient);
            this.options = options;
        }

        /// <inheritdoc />
        public Task<Interview> DetailsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<Interview>(this.options.BaseUrl, $"/api/v1/interviews/{id}",
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.DeleteAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}",
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<InterviewHistory> HistoryAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<InterviewHistory>(this.options.BaseUrl, $"/api/v1/interviews/{id}/history",
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<Stream> GetPdfAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.SendRequest(this.options.BaseUrl, $"/api/v1/interviews/{id}/pdf",
                this.options.Credentials, null, cancellationToken, "GET");
        }

        /// <inheritdoc />
        public Task<InterviewStatistics> StatisticsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<InterviewStatistics>(this.options.BaseUrl, $"/api/v1/interviews/{id}/stats",
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task ApproveAsync(Guid id, string? comment = null, CancellationToken cancellationToken = default)
        {
            var query = new {comment}.GetQueryString();
            return this.requestExecutor.PatchAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}/approve?" + query, null,
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task AssignAsync(Guid id, AssignInterviewRequest assignRequest, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PatchAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}/assign", assignRequest,
                this.options.Credentials, cancellationToken);
        }

        public Task AssignSupervisorAsync(Guid id, AssignInterviewRequest assignRequest,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PatchAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}/assignsupervisor", assignRequest,
                this.options.Credentials, cancellationToken);
        }

        public Task HqApproveAsync(Guid id, string? comment = null, CancellationToken cancellationToken = default)
        {
            var query = new {comment}.GetQueryString();
            return this.requestExecutor.PatchAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}/hqapprove?" + query, null,
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task HqRejectAsync(Guid id, string? comment = null, Guid? responsibleId = null, CancellationToken cancellationToken = default)
        {
            var query = new {comment }.GetQueryString();
            return this.requestExecutor.PatchAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}/hqapprove?" + query, null,
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task HqUnapproveAsync(Guid id, string? comment = null, CancellationToken cancellationToken = default)
        {
            var query = new {comment }.GetQueryString();
            return this.requestExecutor.PatchAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}/hqunapprove?" + query, null,
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task RejectAsync(Guid id, Guid? responsibleId = null, string? comment = null,
            CancellationToken cancellationToken = default)
        {
            var query = new {comment, responsibleId}.GetQueryString();
            return this.requestExecutor.PatchAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}/reject?" + query, null,
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task CommentAsync(Guid id, Guid questionId, string commentText, RosterVector? rosterVector = null, CancellationToken cancellationToken = default)
        {
            var query = new {comment = commentText, 
                rosterVector = rosterVector?.ToArray()}.GetQueryString();
            return this.requestExecutor.PostAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}/comment/{questionId}?" + query, null,
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task CommentAsync(Guid id, string variableName, string commentText,  RosterVector? rosterVector = null, CancellationToken cancellationToken = default)
        {
            var query = new
            {
                comment = commentText,
                rosterVector = rosterVector?.ToArray()
            }.GetQueryString();
            return this.requestExecutor.PostAsync(this.options.BaseUrl, $"/api/v1/interviews/{id}/comment-by-variable/{variableName}?" + query, null,
                this.options.Credentials, cancellationToken);
        }
    }
}