using System;
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
        /// <returns></returns>
        Task<InterviewerUserApiDetails> GetInterviewerDetailsAsync(Guid userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets list of Supervisors.
        /// </summary>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<UserList> SupervisorsListAsync(int limit = 10, int offset = 1,
            CancellationToken cancellationToken = default);
    }
}