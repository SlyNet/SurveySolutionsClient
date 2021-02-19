using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <summary>
    /// Wraps export related actions
    /// </summary>
    public class ExportApi : IExport
    {
        private readonly SurveySolutionsApiConfiguration options;
        private readonly RequestExecutor requestExecutor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportApi"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The options.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public ExportApi(HttpClient httpClient, SurveySolutionsApiConfiguration options)
        {
            this.options = options;
            this.requestExecutor = new RequestExecutor(httpClient);
        }

        /// <inheritdoc />
        public Task<List<ExportProcess>> ListAsync(ExportListRequest filteringArgs, CancellationToken cancellationToken = default)
        {
            var queryString = filteringArgs.GetQueryString();
            return this.requestExecutor.GetAsync<List<ExportProcess>>(this.options.BaseUrl, "/api/v2/export?" + queryString,
                this.options.Credentials, cancellationToken);
        }

        public Task<ExportProcess> DetailsAsync(long id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<ExportProcess>(this.options.BaseUrl, $"/api/v2/export/{id}",
                this.options.Credentials, cancellationToken);
        }

        public Task<ExportProcess> StartAsync(CreateExportProcess body, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PostAsync<ExportProcess>(this.options.BaseUrl, "/api/v2/export", body,
                this.options.Credentials, cancellationToken);
        }

        public Task<ExportProcess> CancelAsync(long id, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.DeleteAsync<ExportProcess>(this.options.BaseUrl, $"/api/v2/export/{id}", 
                this.options.Credentials, cancellationToken);
        }
    }
}