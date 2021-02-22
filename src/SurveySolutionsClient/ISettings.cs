using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <summary>
    /// Settings api
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Gets the global notice.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<GlobalNotice> GetGlobalNoticeAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the global notice.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task SetGlobalNoticeAsync(SetGlobalNoticeApiModel request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Clears the global notice.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ClearGlobalNoticeAsync(CancellationToken cancellationToken = default);
    }
}