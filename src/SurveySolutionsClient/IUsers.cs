using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <summary>
    /// Users api
    /// </summary>
    public interface IUsers
    {
        /// <summary>
        /// Gets the interviewer details.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<InterviewerUserDetails> GetInterviewerDetailsAsync(Guid userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets list of Supervisors.
        /// </summary>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<UserList> SupervisorsListAsync(int limit = 10, int offset = 1,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the supervisor details.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<UserDetails> GetSupervisorDetailsAsync(Guid userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the user details.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<UserDetails> GetUserDetailsAsync(string userName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Archives the specified user by id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task Archive(Guid userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Un archives the specified user by id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task UnArchive(Guid userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns audit log records for interviewer.
        /// You can specify "start" and "end" parameters in query string to get range results.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<List<AuditLogRecord>> GetActionsLogAsync(Guid id, DateTime? start = null, DateTime? end = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Registers the new user.
        /// </summary>
        /// <param name="model">User details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RegisterAsync(RegisterUserModel model, CancellationToken cancellationToken = default);
    }
}