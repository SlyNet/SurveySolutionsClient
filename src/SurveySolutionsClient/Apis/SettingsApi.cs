using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Helpers;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Apis
{
    public class SettingsApi : ISettings
    {
        private readonly SurveySolutionsApiConfiguration options;
        private readonly RequestExecutor requestExecutor;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsApi"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The options.</param>
        public SettingsApi(HttpClient httpClient, SurveySolutionsApiConfiguration options)
        {
            this.options = options;
            this.requestExecutor = new RequestExecutor(httpClient);
        }


        /// <inheritdoc />
        public Task<GlobalNotice> GetGlobalNoticeAsync(CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<GlobalNotice>(this.options.BaseUrl, "/api/v1/settings/globalnotice",
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task SetGlobalNoticeAsync(GlobalNoticeRequest request,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PutAsync(this.options.BaseUrl, "/api/v1/settings/globalnotice", request,
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task ClearGlobalNoticeAsync(CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.DeleteAsync(this.options.BaseUrl, "/api/v1/settings/globalnotice", 
                this.options.Credentials, cancellationToken);
        }
    }
}