using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <summary>
    /// Entry point to all api of Survey Solutions
    /// </summary>
    public interface ISurveySolutionsApi
    {
        /// <summary>
        /// Gets assignments related api actions
        /// </summary>
        IAssignments Assignments { get; }
    }

    /// <summary>
    /// Assignments related actions
    /// </summary>
    public interface IAssignments
    {
        /// <summary>
        /// Gets single assignment details
        /// </summary>
        /// <param name="id">Assignment id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<FullAssignmentDetails> DetailsAsync(int id, CancellationToken cancellationToken = default);

        Task<AssignmentsListView> ListAsync(AssignmentsListFilter filter, CancellationToken cancellationToken = default);
    }
}