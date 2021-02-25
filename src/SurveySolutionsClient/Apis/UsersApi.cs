using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication.ExtendedProtection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using SurveySolutionsClient.Helpers;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Apis
{
    public class UsersApi : IUsers
    {
        private readonly SurveySolutionsApiConfiguration options;
        private readonly RequestExecutor requestExecutor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportApi"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The options.</param>
        public UsersApi(HttpClient httpClient, SurveySolutionsApiConfiguration options)
        {
            this.options = options;
            this.requestExecutor = new RequestExecutor(httpClient);
        }

        /// <inheritdoc />
        public Task<InterviewerUserDetails> GetInterviewerDetailsAsync(Guid userId,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<InterviewerUserDetails>(this.options.TargetUrlWithWorkspace,
                $"/api/v1/interviewers/{userId}",
                this.options.Credentials,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<UserList> SupervisorsListAsync(int limit = 10, int offset = 1,
            CancellationToken cancellationToken = default)
        {
            var query = new {limit, offset};
            return this.requestExecutor.GetAsync<UserList>(this.options.TargetUrlWithWorkspace,
                $"/api/v1/supervisors?" + query.GetQueryString(),
                this.options.Credentials,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<UserDetails> GetSupervisorDetailsAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<UserDetails>(this.options.TargetUrlWithWorkspace,
                $"/api/v1/supervisors/{userId}",
                this.options.Credentials,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<UserDetails> GetUserDetailsAsync(string userName, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<UserDetails>(this.options.TargetUrlWithWorkspace,
                $"/api/v1/users/{HttpUtility.UrlEncode(userName)}",
                this.options.Credentials,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task Archive(Guid userId, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PatchAsync(this.options.TargetUrlWithWorkspace, $"/api/v1/users/{userId}/archive", null, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task UnArchive(Guid userId, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PatchAsync(this.options.TargetUrlWithWorkspace, $"/api/v1/users/{userId}/unarchive", null, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<List<AuditLogRecord>> GetActionsLogAsync(Guid id, DateTime? start = null, DateTime? end = null,
            CancellationToken cancellationToken = default)
        {
            var query = new {start, end}.GetQueryString();

            return this.requestExecutor.GetAsync<List<AuditLogRecord>>(this.options.TargetUrlWithWorkspace,
                $"/api/v1/interviewers/{id}/actions-log?" + query,
                this.options.Credentials,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task RegisterAsync(RegisterUserModel model, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PostAsync(this.options.TargetUrlWithWorkspace, "/api/v1/users", model, this.options.Credentials,
                cancellationToken);
        }
    }
}