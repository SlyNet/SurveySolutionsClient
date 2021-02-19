using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <summary>
    /// Wraps export related actions
    /// </summary>

    public interface IExport
    {
        /// <summary>
        /// Get lists of export jobs.
        /// </summary>
        /// <param name="filteringArgs">The filtering arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>List of jobs that exist on server.</returns>
        Task<List<ExportProcess>> ListAsync(ExportListRequest filteringArgs, CancellationToken cancellationToken = default);


        /// <summary>
        /// Gets Details of the single job by job id.
        /// </summary>
        /// <param name="id">The identifier of the job.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<ExportProcess> DetailsAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Starts the new export job.
        /// </summary>
        /// <param name="body">The argument of export.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Scheduled job details</returns>
        Task<ExportProcess> StartAsync(CreateExportProcess body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels the export job.
        /// </summary>
        /// <param name="id">The identifier of job to be cancelled.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Cancelled job details</returns>
        Task<ExportProcess> CancelAsync(long id, CancellationToken cancellationToken = default);
    }
}