using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Helpers;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Apis
{
    public class WorkSpacesApi : IWorkSpaces
    {
        private readonly SurveySolutionsApiConfiguration options;
        private readonly RequestExecutor requestExecutor;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorkSpacesApi" /> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The options.</param>
        public WorkSpacesApi(HttpClient httpClient, SurveySolutionsApiConfiguration options)
        {
            this.options = options;
            this.requestExecutor = new RequestExecutor(httpClient);
        }

        /// <inheritdoc />
        public Task<WorkspacesList> ListAsync(WorkspacesListFilter filter,
            CancellationToken cancellationToken = default)
        {
            var queryString = filter.GetQueryString();
            return this.requestExecutor.GetAsync<WorkspacesList>(this.options.TargetUrlWithWorkspace,
                "/api/v1/workspaces?" + queryString,
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<Workspace> CreateAsync(WorkspaceCreateRequest request,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PostAsync<Workspace>(this.options.BaseUrl, "/api/v1/workspaces",
                request, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<WorkspacesList> GetDetailsAsync(string name, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<WorkspacesList>(this.options.BaseUrl,
                $"/api/v1/workspaces/{name}",
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task UpdateAsync(string name, WorkspaceUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PatchAsync(this.options.BaseUrl,
                $"/api/v1/workspaces/{name}",
                request, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string name, 
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.DeleteAsync(this.options.BaseUrl,
                $"/api/v1/workspaces/{name}",
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task<WorkspaceStatus> GetStatusAsync(string name, CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.GetAsync<WorkspaceStatus>(this.options.BaseUrl,
                $"/api/v1/workspaces/status/{name}",
                this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task DisableAsync(string name,
            CancellationToken cancellationToken = default)
        {
            var path = $"/api/v1/workspaces/{name}/disable";
            return this.requestExecutor.PostAsync(this.options.BaseUrl,
                path,
                null, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task EnableAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PostAsync(this.options.BaseUrl,
                $"/api/v1/workspaces/{name}/enable",
                null, this.options.Credentials, cancellationToken);
        }

        /// <inheritdoc />
        public Task AssignAsync(AssignWorkspacesToUserRequest request,
            CancellationToken cancellationToken = default)
        {
            return this.requestExecutor.PostAsync(this.options.BaseUrl, "/api/v1/workspaces/assign",
                request, this.options.Credentials, cancellationToken);
        }
    }
}