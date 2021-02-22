using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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

        public Task<InterviewerUserApiDetails> GetInterviewerDetailsAsync(Guid userId,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<InterviewerUserApiDetails>(this.options.BaseUrl,
                $"/api/v1/interviewers/{userId}",
                this.options.Credentials,
                cancellationToken);
        }

        public Task<UserList> SupervisorsListAsync(int limit = 10, int offset = 1,
            CancellationToken cancellationToken = default)
        {
            var query = new {limit, offset};
            return this.requestExecutor.GetAsync<UserList>(this.options.BaseUrl,
                $"/api/v1/supervisors?" + query.GetQueryString(),
                this.options.Credentials,
                cancellationToken);
        }
    }
}