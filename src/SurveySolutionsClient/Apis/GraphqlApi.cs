using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.GraphQl;
using SurveySolutionsClient.Helpers;

namespace SurveySolutionsClient.Apis
{
    /// <summary>
    /// Implementation of query execution for GraphQL
    /// </summary>
    /// <seealso cref="SurveySolutionsClient.IGraphQl" />
    public class GraphqlApi : IGraphQl
    {
        private readonly SurveySolutionsApiConfiguration options;
        private RequestExecutor requestExecutor;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphqlApi"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The options.</param>
        public GraphqlApi(HttpClient httpClient, SurveySolutionsApiConfiguration options)
        {
            this.requestExecutor = new RequestExecutor(httpClient);
            this.options = options;
        }

        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public Task<T> ExecuteAsync<T>(GraphQlQueryBuilder query, CancellationToken cancellationToken =  default)
        {
            return this.requestExecutor.PostAsync<T>(this.options.BaseUrl, "/graphql", query, this.options.Credentials, cancellationToken);
        }
    }
}