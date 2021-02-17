using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    public class AssignmentsApi : IAssignments
    {
        private readonly HttpClient httpClient;
        private readonly SurveySolutionsApiConfiguration options;

        public AssignmentsApi(HttpClient httpClient, 
            SurveySolutionsApiConfiguration options)
        {
            this.httpClient = httpClient;
            this.options = options;
        }

        /// <inheritdoc />
        public virtual Task<FullAssignmentDetails> DetailsAsync(int id, CancellationToken cancellationToken = default) =>
            new RequestExecutor(httpClient)
                .GetAsync<FullAssignmentDetails>(options.BaseUrl, $"api/v1/assignments/{id}", options.Credentials, cancellationToken);

        public virtual Task<AssignmentsListView> ListAsync(AssignmentsListFilter filter, CancellationToken cancellationToken = default)
        {
            string queryString = filter.GetQueryString();

            return new RequestExecutor(httpClient)
                .GetAsync<AssignmentsListView>(options.BaseUrl, "api/v1/assignments?" + queryString, options.Credentials, cancellationToken);
        }
    }
}