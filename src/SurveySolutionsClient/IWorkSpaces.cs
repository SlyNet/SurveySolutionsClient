using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <summary>
    /// Wraps work space related actions
    /// </summary>
    public interface IWorkSpaces
    {
        /// <summary>
        /// Gets list of workspaces.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<WorkspacesList> ListAsync(WorkspacesListFilter filter, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates new workspace. Accessible only to administrator.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<Workspace> CreateAsync(WorkspaceCreateRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the details of the specified workspace.
        /// </summary>
        /// <param name="name">The workspace name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<WorkspacesList> GetDetailsAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the workspace.
        /// </summary>
        /// <param name="name">The workspace name.</param>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task UpdateAsync(string name, WorkspaceUpdateRequest request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the workspace.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task DeleteAsync(string name, 
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the status of workspace.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<WorkspaceStatus> GetStatusAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Disables the workspace.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task DisableAsync(string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Enables the workspace.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task EnableAsync(string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Assigns users into work spaces.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task AssignAsync(AssignWorkspacesToUserRequest request,
            CancellationToken cancellationToken = default);
    }
}