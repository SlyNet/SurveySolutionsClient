using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Exceptions;
using SurveySolutionsClient.Helpers;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Apis
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
        public virtual Task<FullAssignment> DetailsAsync(int id, CancellationToken cancellationToken = default) =>
            this.requestExecutor
                .GetAsync<FullAssignment>(this.options.TargetUrlWithWorkspace, $"/api/v1/assignments/{id}", this.options.Credentials, cancellationToken);

        /// <inheritdoc />
        public virtual Task<AssignmentsListView> ListAsync(AssignmentsListFilter filter, CancellationToken cancellationToken = default)
        {
            string queryString = filter.GetQueryString();

            return this.requestExecutor
                .GetAsync<AssignmentsListView>(this.options.TargetUrlWithWorkspace, "/api/v1/assignments?" + queryString, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public virtual Task<AssignmentHistory> HistoryAsync(int id, int start = 0, int length = 30, CancellationToken cancellationToken = default)
        {
            var query = new {start, length}.GetQueryString();

            return this.requestExecutor
                .GetAsync<AssignmentHistory>(this.options.TargetUrlWithWorkspace, $"/api/v1/assignments/{id}/history?" + query, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<AudioRecordingEnabled> GetAudioRecordingAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .GetAsync<AudioRecordingEnabled>(this.options.TargetUrlWithWorkspace, $"/api/v1/assignments/{id}/recordAudio", this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task SetAudioRecordingAsync(int id, UpdateRecordingRequest request, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync(this.options.TargetUrlWithWorkspace, $"/api/v1/assignments/{id}/recordAudio", request, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<Assignment> ArchiveAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<Assignment>(this.options.TargetUrlWithWorkspace, $"/api/v1/assignments/{id}/archive", null, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<Assignment> UnArchiveAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<Assignment>(this.options.TargetUrlWithWorkspace, $"/api/v1/assignments/{id}/unarchive", null, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<Assignment> AssignAsync(int id, AssignmentResponsible assigneeRequest, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<Assignment>(this.options.TargetUrlWithWorkspace, $"/api/v1/assignments/{id}/assign", assigneeRequest, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<Assignment> ChangeQuantityAsync(int id, int quantity, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<Assignment>(this.options.TargetUrlWithWorkspace, $"/api/v1/assignments/{id}/changeQuantity", quantity, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<Assignment> CloseAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor
                .PatchAsync<Assignment>(this.options.TargetUrlWithWorkspace, $"/api/v1/assignments/{id}/close", null, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<CreateAssignmentResult?> CreateAsync(CreateAssignmentRequest createItem, CancellationToken cancellationToken = default)
        {
            var response = await this.requestExecutor
                .ReceiveResponse(this.options.TargetUrlWithWorkspace, "/api/v1/assignments", this.options.Credentials, createItem, cancellationToken, "POST")
                .ConfigureAwait(false);
            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                if ("text/json".Equals(response.Content.Headers.ContentType.MediaType, StringComparison.OrdinalIgnoreCase) ||
                    "application/json".Equals(response.Content.Headers.ContentType.MediaType, StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        var createAssignmentResult = JsonSerializer.Deserialize<CreateAssignmentResult>(responseBody);
                        throw new AssignmentCreationException("Assignment was not created", createAssignmentResult);
                    }
                    catch (JsonException)
                    {
                        var stringError = JsonSerializer.Deserialize<string>(responseBody);
                        throw new AssignmentCreationException("Assignment was not created", 
                            new CreateAssignmentResult
                        {
                            ValidationErrorMessage = stringError
                        }, new ApiCallException(stringError ?? "Http call exception", responseBody, response))
                        ;
                    }
                }
            }

            if (!response.IsSuccessStatusCode || responseBody == null)
            {
                throw new ApiCallException("Assignment was not created", responseBody, response);
            }

            return JsonSerializer.Deserialize<CreateAssignmentResult>(responseBody);
        }
    }
}